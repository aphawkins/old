namespace Useful.Xml
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using System.Xml;

    public static class XmlSerialization
    {
        public static string Serialize(object source, Encoding encodingOverride, string defaultNamespace = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            // Serialize
            Type objectType = source.GetType();
            XmlSerializer serializer = new XmlSerializer(objectType, defaultNamespace);

            StringBuilder sb = new StringBuilder();

            using (StringWriterWithEncoding strWriter = new StringWriterWithEncoding(sb, encodingOverride))
            {
                serializer.Serialize(strWriter, source);
            }

            return sb.ToString();
        }

        public static string Serialize(object source, string defaultNamespace, XmlWriterSettings settings, XmlSerializerNamespaces namespaces)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            Type objectType = source.GetType();
            XmlSerializer serializer = new XmlSerializer(objectType, defaultNamespace);
            StringBuilder sb = new StringBuilder();

            using (XmlWriter xw = XmlWriter.Create(new StringWriter(sb), settings))
            {
                serializer.Serialize(xw, source, namespaces);
            }

            return sb.ToString();
        }

        public static T Deserialize<T>(string source, string documentRoot = null, string defaultNamespace = null)
        {
            // Deserialize
            XmlSerializer serializer;

            if (!string.IsNullOrEmpty(documentRoot))
            {
                XmlAttributes attrs = new XmlAttributes();
                XmlAttributeOverrides xOver = new XmlAttributeOverrides();
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = documentRoot;
                xRoot.Namespace = defaultNamespace;

                attrs.XmlRoot = xRoot;
                xOver.Add(typeof(T), attrs);

                serializer = new XmlSerializer(typeof(T), xOver);
            }
            else if (!string.IsNullOrEmpty(defaultNamespace))
            {
                serializer = new XmlSerializer(typeof(T), defaultNamespace);
            }
            else
            {
                serializer = new XmlSerializer(typeof(T));
            }

            using (StringReader reader = new StringReader(source))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
