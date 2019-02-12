//-----------------------------------------------------------------------
// <copyright file="XstOptions.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Options required by the XSL transformation procedure.</summary>
//-----------------------------------------------------------------------

namespace Useful.Xml
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Xml;
	using System.Xml.Xsl;

    public class XslOptions
    {
		private List<Tuple<string, string, string>> foundParams;	// namespace, key, value
		private Dictionary<string, string> foundNamespaces;	// ns, nsUri

		public XslOptions()
		{
			this.ExternalDefinitions = true;

			// Default to UTF-8 with no BOM
			XslOptions.DefaultEncoding = new UTF8Encoding(false);
			this.OutputEncoding = XslOptions.DefaultEncoding;

			this.foundParams = new List<Tuple<string, string, string>>();
			this.foundNamespaces = new Dictionary<string, string>();

			this.foundNamespaces.Add("xmlns", string.Empty);
		}

		public static Encoding DefaultEncoding
		{
			get;
			private set;
		}
	
		internal bool RemoveWhitespace { get; set; }

		internal string StartMode { get; set; }

		internal Encoding OutputEncoding { get; set; }

		internal bool ExternalDefinitions { get; set; }

		internal void AddNamespace(string ns, string uri)
		{
			if (this.foundNamespaces.ContainsKey(ns))
			{
				this.foundNamespaces[ns] = uri;
				return;
			}

			this.foundNamespaces.Add(ns, uri);
		}

		/// <summary>
		/// Processes parameters
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		internal void AddParameter(string name, string value)
		{
			/*
			 Expecting name in the form:
			 - (1) xmlns=uri
			 - (2) paramName=paramValue
			 - (3) xmlns:my-ns=uri
			 - (4) my-ns:paramName=paramValue
			*/

			int firstColon = name.IndexOf(':');
			string ns = "xmlns";

			if (firstColon < 0)
			{
				if (string.Equals(name, "xmlns", StringComparison.OrdinalIgnoreCase))
				{
					// (1) Is it a namespace uri?
					this.AddNamespace(ns, value);
					return;
				}

				// (2) Just a name, value param
				this.foundParams.Add(new Tuple<string, string, string>(ns, name, value));
				return;
			}

			ns = name.Substring(0, firstColon);
			name = name.Substring(firstColon + 1);

			if (string.Equals(ns, "xmlns", StringComparison.OrdinalIgnoreCase))
			{
				// (3)
				this.AddNamespace(name, value);
				return;
			}

			// (4)
			this.foundParams.Add(new Tuple<string, string, string>(ns, name, value));
		}

		internal List<Tuple<string, string>> GetInvalidArguments()
		{
			List<Tuple<string, string>> invalids = new List<Tuple<string, string>>();
			XsltArgumentList args = new XsltArgumentList();

			foreach (Tuple<string, string, string> param in this.foundParams)
			{
				string ns = param.Item1;
				string paramName = param.Item2;
				string paramValue = param.Item3;
				string uri = string.Empty;

				if (!string.IsNullOrEmpty(ns))
				{
					uri = this.foundNamespaces[ns];
				}

				try
				{
					args.AddParam(paramName, uri, paramValue);
				}
				catch (XmlException ex)
				{
					invalids.Add(new Tuple<string, string>(paramName, ex.Message));
				}
			}

			return invalids;
		}

		internal XsltArgumentList GetArgumentList()
		{
			XsltArgumentList args = new XsltArgumentList();

			foreach (Tuple<string, string, string> param in this.foundParams)
			{
				string ns = param.Item1;
				string paramName = param.Item2;
				string paramValue = param.Item3;
				string uri = string.Empty;

				if (!string.IsNullOrEmpty(ns))
				{
					uri = this.foundNamespaces[ns];
				}

				args.AddParam(paramName, uri, paramValue);
			}

			return args;
		}

		internal List<string> GetUndefinedPrefixes()
		{
			List<string> prefixes = new List<string>();

			foreach (Tuple<string, string, string> param in this.foundParams)
			{
				string ns = param.Item1;

				if (!string.IsNullOrEmpty(ns)
					&& !this.foundNamespaces.ContainsKey(ns))
				{
					prefixes.Add(ns);
				}
			}

			return prefixes;
		}
    }
}
