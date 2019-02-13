namespace Useful.Tests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Useful.Console;
    using System.Text;

    [TestClass]
    public class XsltUnitTest
    {
        StringBuilder stdErrBuilder = new StringBuilder();
        string stdErr;
        string stdOut;
        int exitCode;

        [TestInitialize()]
        public void TestInitialize()
        {
            this.stdErrBuilder.Clear();
            this.stdErr = string.Empty;
            this.stdOut = string.Empty;
            this.exitCode = 0;
        }

        [TestMethod]
        public void UnknownOption()
        {
            RunTest("{0} -invalid", (int)XsltError.MSXSL_E_UNKNOWN_OPTION);
        }

        [TestMethod]
        public void UnknownOption1()
        {
            RunTest("{0} -unk", (int)XsltError.MSXSL_E_UNKNOWN_OPTION);
        }

        [TestMethod]
        public void UnknownOption2()
        {
            RunTest("{0} books.xml valid.xsl -o valid.out param -xw ", (int)XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
        }

        [TestMethod]
        public void ParamMissingName()
        {
            RunTest("{0} books.xml valid.xsl -o valid.out =val", (int)XsltError.ParamMissingName);
        }

        [TestMethod]
        public void MissingOutput()
        {
            RunTest("{0} -o -?", (int)XsltError.MissingOutput);
        }

        [TestMethod]
        public void MissingParamEquals()
        {
            RunTest("{0} books.xml valid.xsl -o valid.out param + val ", (int)XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
        }

        [TestMethod]
        public void MissingParamEquals1()
        {
            RunTest("{0} books.xml valid.xsl -o valid.out param == val", (int)XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
        }

        [TestMethod]
        public void MissingParamEquals2()
        {
            RunTest("{0} books.xml valid.xsl -o valid.out param ' = ' val ", (int)XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
        }

        [TestMethod]
        public void MissingSource()
        {
            RunTest("{0}", (int)XsltError.MissingSource);
        }

        [TestMethod]
        public void MissingStylesheet()
        {
            RunTest("{0} books.xml", (int)XsltError.MissingStyleSheet);
        }

        [TestMethod]
        public void MissingOutput1()
        {
            RunTest("{0} books.xml valid.xsl -o ", (int)XsltError.MissingOutput);
        }

        [TestMethod]
        public void MissingParamValue()
        {
            RunTest("{0} books.xml valid.xsl param=", (int)XsltError.MSXSL_E_MISSING_PARAM_VALUE);
        }

        [TestMethod]
        public void UnknownOption3()
        {
            RunTest("{0} books.xml valid.xsl - ", (int)XsltError.MSXSL_E_UNKNOWN_OPTION);
        }

        [TestMethod]
        public void MissingParamEquals3()
        {
            RunTest("{0} books.xml valid.xsl -o valid.out 'param=val'", (int)XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
        }

        [TestMethod]
        public void DuplicateSwitches()
        {
            RunTest("{0} -t -t -? -xw -xw -? ", (int)XsltError.None);
        }

        [TestMethod]
        public void MissingNamespaceEquals()
        {
            RunTest("{0} books.xml valid.xsl xmlns:foo", (int)XsltError.MSXSL_E_MISSING_NS_EQUALS);
        }

        [TestMethod]
        public void MissingMode()
        {
            RunTest("{0} books.xml valid.xsl -m ", (int)XsltError.MSXSL_E_MISSING_MODE);
        }

        [TestMethod]
        public void MissingUriValue()
        {
            RunTest("{0} books.xml valid.xsl xmlns:foo=", (int)XsltError.MSXSL_E_MISSING_URI_VALUE);
        }

        [TestMethod]
        public void PrefixUndefined()
        {
            RunTest("{0} books.xml valid.xsl foo:bar=val", (int)XsltError.MSXSL_E_PREFIX_UNDEFINED);
        }

        [TestMethod]
        public void UnknownOption4()
        {
            RunTest("{0} -op", (int)XsltError.MSXSL_E_UNKNOWN_OPTION);
        }

        [TestMethod]
        public void MultipleStdIn()
        {
            // RunTest("{0} - - < valid.xsl", (int)XsltError.MSXSL_E_MULTIPLE_STDIN);
            RunTest("{0} - -", (int)XsltError.MSXSL_E_MULTIPLE_STDIN);
        }

        [TestMethod]
        public void UnknownVersion()
        {
            RunTest("{0} -u 2.5 books.xml valid.xsl", (int)XsltError.None);
        }

        [TestMethod]
        public void UnknownVersion1()
        {
            RunTest("{0} -pi books.xml -u", (int)XsltError.None);
        }

        [TestMethod]
        public void PiConflict()
        {
            RunTest("{0} books.xml - -pi", (int)XsltError.ProcessingInstructionConflict);
        }

        [TestMethod]
        public void PiConflict1()
        {
            RunTest("{0} books.xml valid.xsl -pi", (int)XsltError.ProcessingInstructionConflict);
        }

        [TestMethod]
        public void CommandLineParsing1()
        {
            RunTest("{0} /O  	{1}\\cmdln1.xml 	books.xml 	valid.xsl	p1= last-name  p2 = 'first-name'  p3 =price  -xw  ", (int)XsltError.None, "cmdln1.xml");
        }

        [TestMethod]
        public void CommandLineParsing2()
        {
            // Changed path, added space before p2
            //// RunTest("\"{0}\" /XW /Xw   \"../test/books.xml	\"  /xW /xw \"valid.xsl  \"  p1=\"last-name\"p2 =first-name 'p3''=''price' /o  \"{1}\\cmdln2.xml", "cmdln2.xml");
            RunTest("\"{0}\" /XW /Xw   \"./books.xml	\"  /xW /xw \"valid.xsl  \"  p1=\"last-name\" p2 =first-name 'p3''=''price' /o  \"{1}\\cmdln2.xml", (int)XsltError.None, "cmdln2.xml");
        }

        [TestMethod]
        public void CommandLineParsing3()
        {
            // Some of this is just blatently invalid, like this: "foo""bar"
            //// RunTest("\"{0} \"  \"books.xml\"\"valid.xsl\"-o \"{1}\\cmdln3.xml\"\"p1\"\"=\"\"'1' = '1'\"", "cmdln3.xml");
            RunTest("\"{0} \"  \"books.xml\" \"valid.xsl\" -o \"{1}\\cmdln3.xml\" \"p1\" \"=\" \"'1' = '1'\"", (int)XsltError.None, "cmdln3.xml");
        }

        [TestMethod]
        public void Transform()
        {
            RunTest("{0} books.xml ws.xsl -o {1}\\tr1.xml unknown1=val unknown2=val unknown3=val unknown4=val", (int)XsltError.None, "tr1.xml");
        }

        [TestMethod]
        public void Transform2()
        {
            RunTest("{0} -xW books.xml ws.xsl -o {1}\\tr2.xml unknown1=val unknown2=val unknown3=val unknown4=val", (int)XsltError.None, "tr2.xml");
        }

        [TestMethod]
        public void Transform3()
        {
            RunTest("{0} books.xml valid.xsl p1=first-name > {1}\\tr3.xml", (int)XsltError.None, "tr3.xml");
        }

        [TestMethod]
        public void Transform4()
        {
            RunTest("{0} /v /V valid.xml valid.xsl p1='elem' > {1}\\tr4.xml", (int)XsltError.None, "tr4.xml");
        }

        [TestMethod]
        public void Transform5()
        {
            RunTest("{0} invalid.xml copyof.xsl > {1}\\tr5.xml", (int)XsltError.None, "tr5.xml");
        }

        [TestMethod]
        public void Transform6()
        {
            //RunTest("{0} -m foo valid.xml valid.xsl > {1}\\tr6.xml", "tr6.xml");
            RunTest("{0} valid.xml valid_no_mode.xsl > {1}\\tr6.xml", (int)XsltError.None, "tr6.xml");
        }

        [TestMethod]
        public void Transform7()
        {
            //RunTest("{0} valid.xml valid.xsl /M my-ns:foo xmlns:my-ns='http://my.com' my-ns:param='val' > {1}\\tr7.xml", "tr7.xml");
            RunTest("{0} valid.xml valid_no_mode.xsl xmlns:my-ns='http://my.com' my-ns:param='val' > {1}\\tr7.xml", (int)XsltError.None, "tr7.xml");
        }

        [TestMethod]
        public void Transform8()
        {
            //RunTest("{0} valid.xml valid.xsl -m my-ns:foo my-ns:param='val' xmlns:my-ns=\"unknown\" xmlns:my-ns=http://my.com  > {1}\\tr8.xml", "tr8.xml");
            RunTest("{0} valid.xml valid_no_mode.xsl my-ns:param='val' xmlns:my-ns=\"unknown\" xmlns:my-ns=http://my.com  > {1}\\tr8.xml", (int)XsltError.None, "tr8.xml");
        }

        [TestMethod]
        public void Transform9()
        {
            //RunTest("{0} valid.xml valid.xsl xmlns='http://my.com' xmlns:my-ns2='http://my.com2' -m foo my-ns2:param2='val2' param=val > {1}\\tr9.xml", "tr9.xml");
            RunTest("{0} valid.xml valid_no_mode.xsl xmlns='http://my.com' xmlns:my-ns2='http://my.com2' my-ns2:param2='val2' param=val > {1}\\tr9.xml", (int)XsltError.None, "tr9.xml");
        }

        [TestMethod]
        public void Transform10()
        {
            RunTest("{0} books.xml valid.xsl xmlns='http://my.com' xmlns='' p1=first-name p2=last-name p3=price p4=val4 p5=val5>{1}\\tr10.xml", (int)XsltError.None, "tr10.xml");
        }

        [TestMethod]
        public void Transform11()
        {
            //RunTest("{0} books.xml valid.xsl xmlns='http://my.com' xmlns='' xmlns='http://my.com' xmlns:foo='unknown' param=first-name -m foo> {1}\\tr11.xml", "tr11.xml");
            RunTest("{0} books.xml valid_no_mode.xsl xmlns='http://my.com' xmlns='' xmlns='http://my.com' xmlns:foo='unknown' param=first-name > {1}\\tr11.xml", (int)XsltError.None, "tr11.xml");
        }

        [TestMethod]
        public void Transform12()
        {
            RunTest("{0} books.xml valid.xsl p1=first-name | {0} - copyof.xsl > {1}\\tr12.xml", (int)XsltError.None, "tr12.xml");
        }

        [TestMethod]
        public void Transform13()
        {
            RunTest("{0} / copyof.xsl < books.xml > {1}\\tr13.xml", (int)XsltError.None, "tr13.xml");
        }

        [TestMethod]
        public void Transform14()
        {
            RunTest("{0} books.xml / p1=last-name < valid.xsl > {1}\\tr14.xml", (int)XsltError.None, "tr14.xml");
        }

        [TestMethod]
        public void Transform15()
        {
            RunTest("{0} books.xml copyof10.xsl | more | {0} - copyof.xsl | sort > {1}\\tr15.xml ", (int)XsltError.None, "tr15.xml");
        }

        [TestMethod]
        public void Transform16()
        {
            RunTest("{0} copyof.xsl copyof.xsl | {0} books.xml - | sort > {1}\\tr16.xml ", (int)XsltError.None, "tr16.xml");
        }

        [TestMethod]
        public void Transform17()
        {
            RunTest("{0} -u 3.0 books.xml version.xsl > {1}\\tr17.xml ", (int)XsltError.None, "tr17.xml");
        }

        [TestMethod]
        public void Transform18()
        {
            RunTest("{0} books.xml version.xsl -u 4.0 > {1}\\tr18.xml ", (int)XsltError.None, "tr18.xml");
        }

        [TestMethod]
        public void Transform19()
        {
            RunTest("{0} -pi books.xml > {1}\\tr19.xml ", (int)XsltError.None, "tr19.xml");
        }

        [TestMethod]
        public void Transform20()
        {
            RunTest("{0} books.xml -pi p1=val > {1}\\tr20.xml ", (int)XsltError.None, "tr20.xml");
        }

        [TestMethod]
        public void Transform21()
        {
            RunTest("{0} pi.xsl -pi > {1}\\tr21.xml ", (int)XsltError.None, "tr21.xml");
        }

        [TestMethod]
        public void TransformsOutputToConsole()
        {
            RunTest("{0} books.xml valid.xsl", (int)XsltError.None);
        }

        [TestMethod]
        public void TransformError()
        {
            RunTest("{0} unknown.xml valid.xsl", (int)XsltError.MSXSL_E_LOAD_CTXT);
        }

        [TestMethod]
        public void TransformError2()
        {
            RunTest("{0} http://unknown/unknown.xml valid.xsl", (int)XsltError.MSXSL_E_LOAD_CTXT);
        }

        [TestMethod]
        public void TransformError3()
        {
            RunTest("{0} books.xml invalid1.xsl", (int)XsltError.CompileContext);
        }

        [TestMethod]
        public void TransformError4()
        {
            RunTest("{0} books.xml invalid2.xsl > {1}\\trerr4.xml", (int)XsltError.CompileContext, "trerr4.xml");
        }

        [TestMethod]
        public void TransformError5()
        {
            RunTest("{0} books.xml valid.xsl -o \\unknown\\unknown\\unknown\\unknown.txt", (int)XsltError.MSXSL_E_CREATE_FILE_CTXT);
        }

        [TestMethod]
        public void TransformError6()
        {
            RunTest("{0} books.xml valid.xsl -o valid.out  !p!=val", (int)XsltError.MSXSL_E_PARAM_CTXT);
        }

        [TestMethod]
        public void TransformError7()
        {
            RunTest("{0} books.xml valid.xsl xmlns:foo='http://my.com' foo:bar:baz='val'", (int)XsltError.MSXSL_E_PARAM_CTXT);
        }

        [TestMethod]
        public void TransformError8()
        {
            RunTest("{0} books.xml valid.xsl /m foo::=val xmlns:foo=a", (int)XsltError.ModeContext);
        }

        [TestMethod]
        public void TransformError9()
        {
            RunTest("{0} -XW valid.xml copyof.xsl | sort | {0} - copyof.xsl", (int)XsltError.CompileContext);
        }

        [TestMethod]
        public void TransformError10()
        {
            RunTest("{0} -xw invalid1.xsl copyof.xsl | {0} books.xml -", (int)XsltError.CompileContext);
        }

        [TestMethod]
        public void TransformError11()
        {
            RunTest("{0} -Xw invalid2.xsl copyof.xsl | {0} books.xml - > {1}\\trerr11.xml", (int)XsltError.CompileContext, "trerr11.xml");
        }

        [TestMethod]
        public void TransformError12()
        {
            RunTest("{0} -u 2.6 books.xml copyof.xsl", (int)XsltError.None);
        }

        [TestMethod]
        public void TransformError13()
        {
            RunTest("{0} -pi copyof.xsl", (int)XsltError.InvalidPi);
        }

        [TestMethod]
        public void TransformError14()
        {
            RunTest("{0} -pi bad-pi.xml", (int)XsltError.InvalidPi);
        }

        [TestMethod]
        public void TransformError15()
        {
            RunTest("{0} bad-pi2.xml -pi", (int)XsltError.InvalidPi);
        }

        [TestMethod]
        public void TransformError16()
        {
            RunTest("{0} -pi bad-pi3.xml", (int)XsltError.InvalidPi);
        }

        [TestMethod]
        public void ValidationError()
        {
            // Validation error (manually check since URL changes)
            RunTest("{0} -v invalid.xml valid.xsl p1='elem'", (int)XsltError.ParseError);
        }

        [TestMethod]
        public void ResolutionError()
        {
            // Resolution error (manually check since URL changes)
            RunTest("{0} /xe -Xe -XE -xE invalid.xml copyof.xsl", (int)XsltError.CompileContext);
        }

        [TestMethod]
        public void Timings()
        {
            RunTest("{0} -t /t books.xml valid.xsl -T -o {1}\\timings.xml", (int)XsltError.None, "timings.xml");
        }

        private void RunTest(string args, int exitcode)
        {
            RunTest(args, exitcode, null);
        }

        private void RunTest(string args, int exitcode, string diffFile)
        {
            ExecuteCommand(args);

            Assert.AreEqual(this.exitCode, exitcode);

            if (exitcode == 0)
            {
                Assert.AreEqual(this.stdErr, string.Empty);

                if (string.IsNullOrEmpty(diffFile))
                {
                    Assert.AreNotEqual(this.stdOut, string.Empty);
                }
                else
                {
                    // Can produce a stdout as well as a redirect to file
                    // Assert.AreEqual(this.stdOut, string.Empty);
                }
            }
            else
            {
                Assert.AreNotEqual(this.stdErr, string.Empty);
            }

            if (!string.IsNullOrEmpty(diffFile))
            {
                string baseline = File.ReadAllText(Path.Combine("Useful\\Tests\\XsltTest\\baseline", diffFile));

                string output = File.ReadAllText(diffFile);

                Assert.AreEqual(baseline, output);
            }
        }

        private void ExecuteCommand(string args)
        {
            string cmdArgs = string.Format(args, "XSLT.exe", ".");
            cmdArgs = string.Format(" /C \"" + cmdArgs + "\"");


            using (Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = cmdArgs;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();

                // To avoid deadlock on the stdout & error streams
                process.ErrorDataReceived += ErrorDataReceived;
                process.BeginErrorReadLine();

                this.stdOut = process.StandardOutput.ReadToEnd();

                process.WaitForExit();
                this.exitCode = process.ExitCode;
            }

            this.stdErr = this.stdErrBuilder.ToString();

            return;
        }

        private void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            this.stdErrBuilder.Append(e.Data);
        }
    }
}
