//-----------------------------------------------------------------------
// <copyright file="XmlValidation.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Validates XML.</summary>
//-----------------------------------------------------------------------

namespace Useful.Xml
{
	using System;
	using System.Diagnostics.Contracts;
	using System.IO;
	using System.Xml;
	using System.Xml.Schema;

	public class XmlValidation
	{
		private bool isValidXml = false;

		public Exception LastException { get; private set; }

        public bool IsWarning { get; private set; }

		internal bool IsValid(string xml)
		{
			Contract.Requires(xml != null);

			using (TextReader xmlReader = new StringReader(xml))
			{
				return this.IsValid(xmlReader);
			}
		}

        internal bool IsValid(Stream xml)
		{
			Contract.Requires(xml != null);

			using (TextReader xmlReader = new StreamReader(xml))
			{
				return this.IsValid(xmlReader);
			}
		}

		internal bool IsValid(TextReader xml)
		{
			Contract.Requires(xml != null);

			this.Reset();

			// DTD
			XmlReaderSettings dtdSettings = new XmlReaderSettings();
			dtdSettings.DtdProcessing = DtdProcessing.Parse;
			dtdSettings.ValidationType = ValidationType.DTD;
			dtdSettings.ValidationEventHandler += this.ValidationEventHandler;

			// XSD
			XmlReaderSettings xsdSettings = new XmlReaderSettings();
			xsdSettings.DtdProcessing = DtdProcessing.Parse;
			xsdSettings.ValidationType = ValidationType.Schema;
			xsdSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
			//// xsdSettings.ValidationFlags ^= XmlSchemaValidationFlags.ReportValidationWarnings;
			xsdSettings.ValidationEventHandler += this.ValidationEventHandler;

			using (XmlReader dtdReader = XmlReader.Create(xml, dtdSettings))
			{
				using (XmlReader xsdReader = XmlReader.Create(dtdReader, xsdSettings))
				{
					while (xsdReader.Read())
					{
						// Nothing to do!
					}
				}
			}

			return this.isValidXml;
		}

		private void Reset()
		{
			this.isValidXml = true;
			this.LastException = null;
            this.IsWarning = false;
		}

		private void ValidationEventHandler(object sender, ValidationEventArgs e)
		{
			Contract.Requires(sender != null);
			Contract.Requires(e != null);

            this.IsWarning = e.Severity == XmlSeverityType.Warning;
			this.LastException = e.Exception;
            this.isValidXml = this.IsWarning;
		}
	}
}
