//-----------------------------------------------------------------------
// <copyright file="XslTransformation.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Performs XSL transformations.</summary>
//-----------------------------------------------------------------------

namespace Useful.Xml
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Xsl;
    using Useful.IO;

	/// <summary>
	/// A class containing static procedures for quick Xsl Transformation.
	/// </summary>
	public static class XslTransformation
	{
		/// <summary>
		/// Transforms an XML using the XSL.
		/// </summary>
		/// <param name="xml">The XML to transform.</param>
		/// <param name="xsl">The XSL to use to transform.</param>
		/// <returns></returns>
		public static Tuple<string, XslTimings> Transform(string xsl, string xml, XslOptions options)
		{
			Contract.Requires(xsl != null);
			Contract.Requires(xml != null);
			Contract.Requires(options != null);

			using (TextReader xmlReader = new StringReader(xml))
			{
				using (TextReader xslReader = new StringReader(xsl))
				{
					using (Stream output = new MemoryStream())
					{
						XslTimings timing = Transform(xslReader, xmlReader, output, options);

						output.Position = 0;

						using (StreamReader sr = new StreamReader(output, options.OutputEncoding))
						{
							StringBuilder sb = new StringBuilder();

							using (StringWriterWithEncoding xmlWriter = new StringWriterWithEncoding(sb, options.OutputEncoding))
							{
								xmlWriter.Write(sr.ReadToEnd());
								return new Tuple<string, XslTimings>(xmlWriter.ToString(), timing);
							}
						}
					}
				}
			}
		}

        /// <summary>
        /// Transforms the XML using the Processing Instruction
        /// </summary>
        /// <param name="xsl"></param>
        /// <param name="xml"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Tuple<string, XslTimings> Transform(string xml, XslOptions options)
        {
            Contract.Requires(xml != null);
            Contract.Requires(options != null);

            string xslFile = GetPi(xml);

            if (string.IsNullOrEmpty(xslFile))
            {
                throw new XsltException("Invalid Processing Instruction.");
            }

            string xsl = File.ReadAllText(xslFile);

            return Transform(xsl, xml, options);
        }

		/// <summary>
		/// Transforms an XML using the XSL.
		/// </summary>
		/// <param name="xml">The XML to transform.</param>
		/// <param name="xsl">The XSL to use to transform.</param>
		/// <returns></returns>
		public static XslTimings Transform(Stream xsl, Stream xml, Stream output, XslOptions options)
		{
			Contract.Requires(xsl != null);
			Contract.Requires(xml != null);
			Contract.Requires(output != null);
			Contract.Requires(options != null);

			using (TextReader xslReader = new StreamReader(xsl, true))
			{
				using (TextReader xmlReader = new StreamReader(xml, true))
				{
					return Transform(xslReader, xmlReader, output, options);
				}
			}
		}

		/// <summary>
		/// Transforms an XML using the XSL.
		/// </summary>
		/// <param name="xml">The XML to transform, without BOM.</param>
		/// <param name="xsl">The XSL to use to transform, without BOM.</param>
		/// <returns></returns>
		public static XslTimings Transform(TextReader xsl, TextReader xml, Stream output, XslOptions options)
		{
			Contract.Requires(xsl != null);
			Contract.Requires(xml != null);
			Contract.Requires(output != null);
			Contract.Requires(options != null);

			XslTimings timings = new XslTimings();
			Stopwatch timer;
			XsltArgumentList xslArgs = options.GetArgumentList();

			XslProcedures myProcs = new XslProcedures();
			xslArgs.AddExtensionObject("urn:XslProcs", myProcs);

			XmlReaderSettings xmlSettings = new XmlReaderSettings();
			xmlSettings.CloseInput = false;
			xmlSettings.IgnoreWhitespace = options.RemoveWhitespace;
			xmlSettings.DtdProcessing = DtdProcessing.Parse;
			if (!options.ExternalDefinitions)
			{
				xmlSettings.XmlResolver = null;
			}

			XmlReaderSettings xslSettings = new XmlReaderSettings();
			xslSettings.CloseInput = false;

			// Create the XmlReader object.
			using (XmlReader xmlReader = XmlReader.Create(xml, xmlSettings))
			{
				XslCompiledTransform trans = new XslCompiledTransform(false);
				using (XmlReader xslReader = CreateXmlReaderWithMode(xsl, xslSettings, options.StartMode))
				{
					try
					{
						timer = Stopwatch.StartNew();
						trans.Load(xslReader);
						timer.Stop();
						timings.Compile = timer.Elapsed;
					}
					catch (XsltException)
					{
						throw;
					}
				}

				XmlWriterSettings xmlWriteSettings = trans.OutputSettings.Clone();

				if (options.OutputEncoding != null)
				{
					// override the output encoding in the XSL if specified
					xmlWriteSettings.Encoding = options.OutputEncoding;
				}
				else if (xmlWriteSettings.Encoding == XslOptions.DefaultEncoding)
				{
					// If UTF8 set it to have no BOM by default
					xmlWriteSettings.Encoding = new UTF8Encoding(false);
				}

				if (options.RemoveWhitespace)
				{
					// xmlWriteSettings.NewLineChars = string.Empty;
					xmlWriteSettings.NewLineHandling = NewLineHandling.Replace;
					xmlWriteSettings.NewLineOnAttributes = false;
					xmlWriteSettings.IndentChars = string.Empty;
					xmlWriteSettings.Indent = true;
				}

				using (XmlWriter xmlWriter = XmlWriter.Create(output, xmlWriteSettings))
				{
					timer.Restart();
					trans.Transform(xmlReader, xslArgs, xmlWriter);
					timer.Stop();
					timings.Execute = timer.Elapsed;
				}
			}

			return timings;
		}

        internal static string GetPi(string xml)
        {
            Contract.Requires(!string.IsNullOrEmpty(xml));

            XDocument doc = XDocument.Parse(xml);

            ////foreach (var node in xDoc.Nodes())
            ////{
            ////    if (node.NodeType == XmlNodeType.ProcessingInstruction)
            ////    {
            ////        Debug.WriteLine(((XProcessingInstruction)node).Data);
            ////        Debug.WriteLine(Regex.Match(((XProcessingInstruction)node).Data, "[^a-zA-Z]?href\\s*=\\s*\"(?<file>.*?)\"").Success);
            ////    }
            ////}

            var cssUrlQuery = from node in doc.Nodes()
                              where node.NodeType == XmlNodeType.ProcessingInstruction
                              select Regex.Match(((XProcessingInstruction)node).Data, "(\\b|^)href\\s*=\\s*\"(?<file>.*?)\"").Groups["file"].Value;
            //// select (XProcessingInstruction)node;

            return cssUrlQuery.FirstOrDefault();
        }

		private static XmlReader CreateXmlReaderWithMode(TextReader input, XmlReaderSettings settings, string mode)
		{
			Contract.Requires(input != null);

			if (string.IsNullOrEmpty(mode))
			{
				return XmlReader.Create(input, settings);
			}
			else
			{
				if (mode.Contains(":"))
				{
					throw new XsltException("Starting mode may not contain the character ':'.");
				}

				// http://msdn.microsoft.com/en-us/library/windows/desktop/ms763717(v=vs.85).aspx

				// Using setStartMode is essentially the same as an XSLT style sheet that starts with the following rule.
				/*
				<xsl:template match="/">
					<xsl:apply-templates select="*" mode="{mode}"/>
				</xsl:template>
				*/

				XDocument doc = XDocument.Load(input);

				XNamespace ns = doc.Root.GetDefaultNamespace();

				doc.Root.AddFirst(new XElement(ns + "template", new XAttribute("match", "/"), new XElement(ns + "apply-templates", new XAttribute("select", "*"), new XAttribute("mode", mode))));

				return doc.CreateReader();
			}
		}
	}
}
