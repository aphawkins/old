//-----------------------------------------------------------------------
// <copyright file="XmlValidation.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Validates XML.</summary>
//-----------------------------------------------------------------------

namespace XML
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;

    public class XmlValidation
    {
        private bool isValidXml = false;

        public Exception? LastException { get; private set; }

        public bool IsWarning { get; private set; }

        public bool IsValid(string xml)
        {
            Contract.Requires(xml != null);

            using TextReader xmlReader = new StringReader(xml);
            return IsValid(xmlReader);
        }

        internal bool IsValid(Stream xml)
        {
            Contract.Requires(xml != null);

            using TextReader xmlReader = new StreamReader(xml);
            return IsValid(xmlReader);
        }

        internal bool IsValid(TextReader xml)
        {
            Contract.Requires(xml != null);

            Reset();

            // DTD
            XmlReaderSettings dtdSettings = new()
            {
                DtdProcessing = DtdProcessing.Parse,
                ValidationType = ValidationType.DTD
            };
            dtdSettings.ValidationEventHandler += ValidationEventHandler;

            // XSD
            XmlReaderSettings xsdSettings = new()
            {
                DtdProcessing = DtdProcessing.Parse,
                ValidationType = ValidationType.Schema
            };
            xsdSettings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            //// xsdSettings.ValidationFlags ^= XmlSchemaValidationFlags.ReportValidationWarnings;
            xsdSettings.ValidationEventHandler += ValidationEventHandler;

            using (XmlReader dtdReader = XmlReader.Create(xml, dtdSettings))
            {
                using XmlReader xsdReader = XmlReader.Create(dtdReader, xsdSettings);
                while (xsdReader.Read())
                {
                    // Nothing to do!
                }
            }

            return isValidXml;
        }

        private void Reset()
        {
            isValidXml = true;
            LastException = null;
            IsWarning = false;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            Contract.Requires(sender != null);
            Contract.Requires(e != null);

            IsWarning = e.Severity == XmlSeverityType.Warning;
            LastException = e.Exception;
            isValidXml = IsWarning;
        }
    }
}
