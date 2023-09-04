namespace XMLTests
{
    using System.IO;
    using Useful.Xml;

    public class XmlValidationUnitTests
    {
        [Fact]
        public void Validation()
        {
            Assert.True(RunValidationFile("books.xml"));
        }

        [Fact]
        public void ValidationError()
        {
            //Tuple<string, XslTimings> response = RunTransformFile("invalid.xml", "valid.xsl", false, true, true, string.Empty, new string[] { "p1=elem" });

            Assert.False(RunValidationFile("invalid.xml"));
        }

        private static bool RunValidationFile(string filename)
        {
            XmlValidation validator = new();

            using FileStream fs = new(filename, FileMode.Open);
            return validator.IsValid(fs);
        }
    }
}
