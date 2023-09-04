namespace Useful.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Globalization;
    using System.Reflection;

	internal static class XmlResourceManager
	{
		internal static Stream LoadTestSchema()
		{
            return LoadResource(@"Useful.Xml.Test.xsd");
		}

		private static Stream LoadResource(string fileName)
		{
			Stream embeddedStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileName);

			if (embeddedStream == null)
			{
				throw new IOException(string.Format(CultureInfo.CurrentCulture, "Could not find the resource file '{0}'.", fileName));
			}

			return embeddedStream;
		}
	}
}
