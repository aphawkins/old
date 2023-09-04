namespace XMLTests
{
    using System.IO;
    using Useful.Console;

    public class XsltUnitTests
    {
        [Fact]
        public void UnknownOption()
        {
            string[] args = new string[] { "-invalid" };
            RunTest(args, (int)XsltError.MSXSL_E_UNKNOWN_OPTION);
        }

        [Fact]
        public void UnknownOption1()
        {
            string[] args = new string[] { "-unk" };
            RunTest(args, (int)XsltError.MSXSL_E_UNKNOWN_OPTION);
        }

        [Fact]
        public void UnknownOption2()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "-o", "valid.out", "param", "-xw" };
            RunTest(args, (int)XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
        }

        [Fact]
        public void ParameterMissingName()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "-o", "valid.out", "=val" };
            RunTest(args, (int)XsltError.ParamMissingName);
        }

        [Fact]
        public void MissingOutput()
        {
            string[] args = new string[] { "-o", "-?" };
            RunTest(args, (int)XsltError.MissingOutput);
        }

        [Fact]
        public void MissingParameterEquals()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "-o", "valid.out", "param", "+", "val" };
            RunTest(args, (int)XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
        }

        [Fact]
        public void MissingParameterEquals1()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "-o", "valid.out", "param", "==", "val" };
            RunTest(args, (int)XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
        }

        [Fact]
        public void MissingParameterEquals2()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "-o", "valid.out", "param", "'", "=", "'", "val" };
            RunTest(args, (int)XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
        }

        [Fact]
        public void MissingSource()
        {
            string[] args = new string[0];
            RunTest(args, (int)XsltError.MissingSource);
        }

        [Fact]
        public void MissingStyleSheet()
        {
            string[] args = new string[] { "books.xml" };
            RunTest(args, (int)XsltError.MissingStyleSheet);
        }

        [Fact]
        public void MissingOutput1()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "-o" };
            RunTest(args, (int)XsltError.MissingOutput);
        }

        [Fact]
        public void MissingParameterValue()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "param=" };
            RunTest(args, (int)XsltError.MSXSL_E_MISSING_PARAM_VALUE);
        }

        [Fact]
        public void UnknownOption3()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "-" };
            RunTest(args, (int)XsltError.MSXSL_E_UNKNOWN_OPTION);
        }

        [Fact]
        public void MissingParameterEquals3()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "-o", "valid.out", "'param=val'" };
            RunTest(args, (int)XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
        }

        [Fact]
        public void DuplicateSwitches()
        {
            string[] args = new string[] { "-t", "-t", "-?", "-xw", "-xw", "-?" };
            RunTest(args, (int)XsltError.None);
        }

        [Fact]
        public void MissingNamespaceEquals()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "xmlns:foo" };
            RunTest(args, (int)XsltError.MSXSL_E_MISSING_NS_EQUALS);
        }

        [Fact]
        public void MissingMode()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "-m" };
            RunTest(args, (int)XsltError.MSXSL_E_MISSING_MODE);
        }

        [Fact]
        public void MissingUriValue()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "xmlns:foo=" };
            RunTest(args, (int)XsltError.MSXSL_E_MISSING_URI_VALUE);
        }

        [Fact]
        public void PrefixUndefined()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "foo:bar=val" };
            RunTest(args, (int)XsltError.MSXSL_E_PREFIX_UNDEFINED);
        }

        [Fact]
        public void UnknownOption4()
        {
            string[] args = new string[] { "-op" };
            RunTest(args, (int)XsltError.MSXSL_E_UNKNOWN_OPTION);
        }

        [Fact]
        public void MultipleStandardIn()
        {
            string[] args = new string[] { "-", "-" };
            RunTest(args, (int)XsltError.MSXSL_E_MULTIPLE_STDIN);
        }

        [Fact]
        public void UnknownVersion()
        {
            string[] args = new string[] { "-u", "2.5", "books.xml", "valid.xsl" };
            RunTest(args, (int)XsltError.None);
        }

        [Fact]
        public void UnknownVersion1()
        {
            string[] args = new string[] { "-pi", "books.xml", "-u" };
            RunTest(args, (int)XsltError.None);
        }

        [Fact]
        public void PiConflict()
        {
            string[] args = new string[] { "books.xml", "-", "-pi" };
            RunTest(args, (int)XsltError.ProcessingInstructionConflict);
        }

        [Fact]
        public void PiConflict1()
        {
            string[] args = new string[] { "books.xml", "valid.xsl", "-pi" };
            RunTest(args, (int)XsltError.ProcessingInstructionConflict);
        }

        [Fact]
        public void CommandLineParsing1()
        {
            string[] args = new string[] { "/O", ".\\cmdln1.xml", "books.xml", "valid.xsl", "p1=", "last-name", "p2", "=", "'first-name'", "p3", "=price", "-xw" };
            RunTest(args, (int)XsltError.None, "cmdln1.xml");
        }

        [Fact]
        public void CommandLineParsing2()
        {
            string[] args = new string[] { "/XW", "/Xw", "./books.xml	", "/xW", "/xw", "valid.xsl  ", "p1=last-name", "p2", "=first-name", "'p3''=''price'", "/o", ".\\cmdln2.xml" };
            RunTest(args, (int)XsltError.None, "cmdln2.xml");
        }

        [Fact]
        public void CommandLineParsing3()
        {
            // Some of this is just blatently invalid, like this: "foo""bar"
            //// RunTest("\"{0} \"  \"books.xml\"\"valid.xsl\"-o \"{1}\\cmdln3.xml\"\"p1\"\"=\"\"'1' = '1'\"", "cmdln3.xml");
            string[] args = new string[] { "books.xml", "valid.xsl", "-o", ".\\cmdln3.xml", "p1", "=", "'1' = '1'" };
            RunTest(args, (int)XsltError.None, "cmdln3.xml");
        }

        private static void RunTest(string[] args, int exitcode)
        {
            RunTest(args, exitcode, null);
        }

        private static void RunTest(string[] args, int exitcode, string? diffFile)
        {
            int result = Xslt.Main(args);

            Assert.Equal(result, exitcode);

            if (!string.IsNullOrEmpty(diffFile))
            {
                string baseline = File.ReadAllText(Path.Combine("Useful\\Tests\\XsltTest\\baseline", diffFile));

                string output = File.ReadAllText(diffFile);

                Assert.Equal(baseline, output);
            }
        }
    }
}
