namespace Useful.Xml
{
	using System;
	using System.Diagnostics;
	using System.IO;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Useful.Console;
    using Useful.Xml;
    using System.Linq;
    using System.Xml.Xsl;
    using System.Xml;

	[TestClass]
    public class XmlValidationUnitTests
	{
        [TestMethod]
        public void Validation()
        {
            Assert.IsTrue(RunValidationFile("books.xml"));
        }

        [TestMethod]
        public void ValidationError()
        {
            //Tuple<string, XslTimings> response = RunTransformFile("invalid.xml", "valid.xsl", false, true, true, string.Empty, new string[] { "p1=elem" });

            Assert.IsFalse(RunValidationFile("invalid.xml"));
        }

        private static bool RunValidationFile(string filename)
        {
            XmlValidation validator = new XmlValidation();
            
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                return validator.IsValid(fs);
            }
        }
    }
}
