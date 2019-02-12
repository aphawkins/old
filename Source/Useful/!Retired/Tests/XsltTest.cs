namespace Useful.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Diagnostics;
	using System.IO;
	using Useful.Console;

    class XsltTest
    {
        bool fFoundError = false;

        string stdErr;
        int exitCode;

        static void Main(string[] args)
        {
            // TODO: create folders

            XsltTest prog = new XsltTest();
            prog.Go();
            Console.Read();
        }

        private void Go()
        {
            //Console.WriteLine();
            //Console.WriteLine("==========================================================");
            //Console.WriteLine("Command Line Errors ...");
            //Console.WriteLine("==========================================================");
            //
            //RunTest("{0} -invalid", XsltError.MSXSL_E_UNKNOWN_OPTION);
            //RunTest("{0} -o -?", XsltError.MSXSL_E_MISSING_OUTPUT);
            //RunTest("{0} -unk", XsltError.MSXSL_E_UNKNOWN_OPTION);
            //RunTest("{0} books.xml valid.xsl -o valid.out param -xw ", XsltError.MSXSL_E_UNKNOWN_OPTION);
            //RunTest("{0} books.xml valid.xsl -o valid.out =val", XsltError.ParamMissingName);
            //RunTest("{0} books.xml valid.xsl -o valid.out param + val ", XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
            //RunTest("{0} books.xml valid.xsl -o valid.out param == val", XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
            //RunTest("{0} books.xml valid.xsl -o valid.out param ' = ' val ", XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
            //RunTest("{0}", XsltError.MSXSL_E_MISSING_SOURCE);
            //RunTest("{0} books.xml", XsltError.MSXSL_E_MISSING_STYLESHEET);
            //RunTest("{0} books.xml valid.xsl -o ", XsltError.MSXSL_E_MISSING_OUTPUT);
            //RunTest("{0} books.xml valid.xsl param=", XsltError.MSXSL_E_MISSING_PARAM_VALUE);
            //RunTest("{0} books.xml valid.xsl - ", XsltError.MSXSL_E_UNKNOWN_OPTION);
            //RunTest("{0} books.xml valid.xsl -o valid.out 'param=val'", XsltError.MSXSL_E_MISSING_PARAM_EQUALS);
            //RunTest("{0} -t -t -? -xw -xw -? ", XsltError.None); // XsltError.XSLT_E_DUPLICATE_SWITCH);
            //RunTest("{0} books.xml valid.xsl -m ", XsltError.MSXSL_E_MISSING_MODE);
            //RunTest("{0} books.xml valid.xsl xmlns:foo", XsltError.MSXSL_E_MISSING_NS_EQUALS);
            //RunTest("{0} books.xml valid.xsl xmlns:foo=", XsltError.MSXSL_E_MISSING_URI_VALUE);
            //RunTest("{0} books.xml valid.xsl foo:bar=val", XsltError.MSXSL_E_PREFIX_UNDEFINED);
            //RunTest("{0} -op", XsltError.MSXSL_E_UNKNOWN_OPTION);
            //RunTest("{0} - - < valid.xsl", XsltError.MSXSL_E_MULTIPLE_STDIN);
            //RunTest("{0} -u 2.5 books.xml valid.xsl", XsltError.None);
            //RunTest("{0} -pi books.xml -u", XsltError.None);
            //RunTest("{0} books.xml - -pi", XsltError.MSXSL_E_PI_CONFLICT);
            //RunTest("{0} books.xml valid.xsl -pi", XsltError.MSXSL_E_PI_CONFLICT);

			//Console.WriteLine();
			//Console.WriteLine("==========================================================");
			//Console.WriteLine("Command Line Parsing ...");
			//Console.WriteLine("==========================================================");

			//RunTest("{0} /O  	{1}\\cmdln1.xml 	books.xml 	valid.xsl	p1= last-name  p2 = 'first-name'  p3 =price  -xw  ", "cmdln1.xml");

			//// Changed path, added space before p2
			////// RunTest("\"{0}\" /XW /Xw   \"../test/books.xml	\"  /xW /xw \"valid.xsl  \"  p1=\"last-name\"p2 =first-name 'p3''=''price' /o  \"{1}\\cmdln2.xml", "cmdln2.xml");
			//RunTest("\"{0}\" /XW /Xw   \"./books.xml	\"  /xW /xw \"valid.xsl  \"  p1=\"last-name\" p2 =first-name 'p3''=''price' /o  \"{1}\\cmdln2.xml", "cmdln2.xml");

			//// Some of this is just blatently invalid, like this: "foo""bar"
			////// RunTest("\"{0} \"  \"books.xml\"\"valid.xsl\"-o \"{1}\\cmdln3.xml\"\"p1\"\"=\"\"'1' = '1'\"", "cmdln3.xml");
			//RunTest("\"{0} \"  \"books.xml\" \"valid.xsl\" -o \"{1}\\cmdln3.xml\" \"p1\" \"=\" \"'1' = '1'\"", "cmdln3.xml");

			//Console.WriteLine();
			//Console.WriteLine("==========================================================");
			//Console.WriteLine("Transforms ...");
			//Console.WriteLine("==========================================================");

			//RunTest("{0} books.xml ws.xsl -o {1}\\tr1.xml unknown1=val unknown2=val unknown3=val unknown4=val", "tr1.xml");
			//RunTest("{0} -xW books.xml ws.xsl -o {1}\\tr2.xml unknown1=val unknown2=val unknown3=val unknown4=val", "tr2.xml");
			//RunTest("{0} books.xml valid.xsl p1=first-name > {1}\\tr3.xml", "tr3.xml");
			//RunTest("{0} /v /V valid.xml valid.xsl p1='elem' > {1}\\tr4.xml", "tr4.xml");
			//RunTest("{0} invalid.xml copyof.xsl > {1}\\tr5.xml", "tr5.xml");

            ////RunTest("{0} -m foo valid.xml valid.xsl > {1}\\tr6.xml", "tr6.xml");
            //RunTest("{0} valid.xml valid_no_mode.xsl > {1}\\tr6.xml", "tr6.xml");
            ////RunTest("{0} valid.xml valid.xsl /M my-ns:foo xmlns:my-ns='http://my.com' my-ns:param='val' > {1}\\tr7.xml", "tr7.xml");
            //RunTest("{0} valid.xml valid_no_mode.xsl xmlns:my-ns='http://my.com' my-ns:param='val' > {1}\\tr7.xml", "tr7.xml");
            ////RunTest("{0} valid.xml valid.xsl -m my-ns:foo my-ns:param='val' xmlns:my-ns=\"unknown\" xmlns:my-ns=http://my.com  > {1}\\tr8.xml", "tr8.xml");
            //RunTest("{0} valid.xml valid_no_mode.xsl my-ns:param='val' xmlns:my-ns=\"unknown\" xmlns:my-ns=http://my.com  > {1}\\tr8.xml", "tr8.xml");
            ////RunTest("{0} valid.xml valid.xsl xmlns='http://my.com' xmlns:my-ns2='http://my.com2' -m foo my-ns2:param2='val2' param=val > {1}\\tr9.xml", "tr9.xml");
            //RunTest("{0} valid.xml valid_no_mode.xsl xmlns='http://my.com' xmlns:my-ns2='http://my.com2' my-ns2:param2='val2' param=val > {1}\\tr9.xml", "tr9.xml");
            //RunTest("{0} books.xml valid.xsl xmlns='http://my.com' xmlns='' p1=first-name p2=last-name p3=price p4=val4 p5=val5>{1}\\tr10.xml", "tr10.xml");
            ////RunTest("{0} books.xml valid.xsl xmlns='http://my.com' xmlns='' xmlns='http://my.com' xmlns:foo='unknown' param=first-name -m foo> {1}\\tr11.xml", "tr11.xml");
            //RunTest("{0} books.xml valid_no_mode.xsl xmlns='http://my.com' xmlns='' xmlns='http://my.com' xmlns:foo='unknown' param=first-name > {1}\\tr11.xml", "tr11.xml");
            //RunTest("{0} books.xml valid.xsl p1=first-name | {0} - copyof.xsl > {1}\\tr12.xml", "tr12.xml");
            //RunTest("{0} / copyof.xsl < books.xml > {1}\\tr13.xml", "tr13.xml");
            //RunTest("{0} books.xml / p1=last-name < valid.xsl > {1}\\tr14.xml", "tr14.xml");
            //RunTest("{0} books.xml copyof10.xsl | more | {0} - copyof.xsl | sort > {1}\\tr15.xml ", "tr15.xml");
            //RunTest("{0} copyof.xsl copyof.xsl | {0} books.xml - | sort > {1}\\tr16.xml ", "tr16.xml");
            //RunTest("{0} -u 3.0 books.xml version.xsl > {1}\\tr17.xml ", "tr17.xml");
            //RunTest("{0} books.xml version.xsl -u 4.0 > {1}\\tr18.xml ", "tr18.xml");
            //RunTest("{0} -pi books.xml > {1}\\tr19.xml ", "tr19.xml");
            //RunTest("{0} books.xml -pi p1=val > {1}\\tr20.xml ", "tr20.xml");
            //RunTest("{0} pi.xsl -pi > {1}\\tr21.xml ", "tr21.xml");

            //Console.WriteLine();
            //Console.WriteLine("----- Output to console (manually check since can't redirect to file)");
            //RunTest("{0} books.xml valid.xsl");

            //Console.WriteLine();
            //Console.WriteLine("==========================================================");
            //Console.WriteLine("Transform Errors ...");
            //Console.WriteLine("==========================================================");

            //RunTest("{0} unknown.xml valid.xsl", XsltError.MSXSL_E_LOAD_CTXT);
            //RunTest("{0} http://unknown/unknown.xml valid.xsl", XsltError.MSXSL_E_LOAD_CTXT);
            //RunTest("{0} books.xml invalid1.xsl", XsltError.MSXSL_E_COMPILE_CTXT);
            //RunTest("{0} books.xml invalid2.xsl > {1}\\trerr4.xml", XsltError.MSXSL_E_COMPILE_CTXT, "trerr4.xml");
            //RunTest("{0} books.xml valid.xsl -o \\unknown\\unknown\\unknown\\unknown.txt", XsltError.MSXSL_E_CREATE_FILE_CTXT);
            //RunTest("{0} books.xml valid.xsl -o valid.out  !p!=val", XsltError.MSXSL_E_PARAM_CTXT);
            //RunTest("{0} books.xml valid.xsl xmlns:foo='http://my.com' foo:bar:baz='val'", XsltError.MSXSL_E_PARAM_CTXT);
            //RunTest("{0} books.xml valid.xsl /m foo::=val xmlns:foo=a", XsltError.MSXSL_E_MODE_CTXT);
            //RunTest("{0} -XW valid.xml copyof.xsl | sort | {0} - copyof.xsl", XsltError.MSXSL_E_COMPILE_CTXT);
            //RunTest("{0} -xw invalid1.xsl copyof.xsl | {0} books.xml -", XsltError.MSXSL_E_COMPILE_CTXT);
            //RunTest("{0} -Xw invalid2.xsl copyof.xsl | {0} books.xml - > {1}\\trerr11.xml", XsltError.MSXSL_E_COMPILE_CTXT, "trerr11.xml");
            //RunTest("{0} -u 2.6 books.xml copyof.xsl", XsltError.None);
            //RunTest("{0} -pi copyof.xsl", XsltError.MSXSL_E_INVALID_PI);
            //RunTest("{0} -pi bad-pi.xml", XsltError.MSXSL_E_INVALID_PI);
            //RunTest("{0} bad-pi2.xml -pi", XsltError.MSXSL_E_INVALID_PI);
            //RunTest("{0} -pi bad-pi3.xml", XsltError.MSXSL_E_INVALID_PI);

            //Console.WriteLine();
            //Console.WriteLine("----- Validation error (manually check since URL changes)");
            //RunTest("{0} -v invalid.xml valid.xsl p1='elem'", XsltError.MSXSL_E_PARSE_ERROR);

            //Console.WriteLine();
            //Console.WriteLine("----- Resolution error (manually check since URL changes)");
            //RunTest("{0} /xe -Xe -XE -xE invalid.xml copyof.xsl", XsltError.MSXSL_E_COMPILE_CTXT);

            //Console.WriteLine();
            //Console.WriteLine("==========================================================");
            //Console.WriteLine("Timings ...");
            //Console.WriteLine("==========================================================");
            //RunTest("{0} -t /t books.xml valid.xsl -T -o {1}\\timings.xml", "timings.xml");

            Console.WriteLine();
            Console.WriteLine("==========================================================");
            Console.WriteLine("MSXSL Tests {0}", fFoundError ? "FAILED" : "PASSED");
            Console.WriteLine("==========================================================");
        }

		private void RunTest(string args)
		{
            RunTest(args, XsltError.None, null);
		}

		private void RunTest(string args, string diffFile)
		{
            RunTest(args, XsltError.None, diffFile);
		}

        private void RunTest(string args, XsltError errorCode)
        {
            RunTest(args, errorCode, null);
        }

        private void RunTest(string args, XsltError errorCode, string diffFile)
        {
            if (diffFile != null)
            {
                Console.WriteLine("----- {0}", diffFile);
            }

            ExecuteCommand(args, false); // diffFile == null);

            Diff(this.exitCode, (int)errorCode, "oops");

            if (errorCode == XsltError.None)
            {
                if (!string.IsNullOrEmpty(this.stdErr))
                {
                    Diff("a", "b", "XSLT produced a STDERR, but shouldn't have.");
                    return;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.stdErr))
                {
                    Diff("a", "b", "XSLT didn't produce a STDERR, but should have.");
                    return;
                }
            }

            if (diffFile != null)
            {
                string baseline = File.ReadAllText(Path.Combine("Useful\\Tests\\XsltTest\\baseline", diffFile));

                string output = File.ReadAllText(diffFile);

                Diff(baseline, output, "XSLT STDOUT different to baseline file.");
            }
        }

        private void ExecuteCommand(string args, bool printOutput)
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
                process.StartInfo.RedirectStandardOutput = printOutput;
                process.StartInfo.RedirectStandardError = true;
				process.Start();

				this.stdErr = process.StandardError.ReadToEnd();

				if (printOutput)
				{
					Console.WriteLine(process.StandardOutput.ReadToEnd());
				}
				else
				{
					process.WaitForExit();
					this.exitCode = process.ExitCode;
				}
            }

            return;
        }

        private void Diff(string a, string b, string message)
        {
            if (!string.Equals(a, b))
            {
                fFoundError = true;
                Console.WriteLine(message);
            }
        }

		private void Diff(int a, int b, string message)
		{
			if (a != b)
			{
				fFoundError = true;
				Console.WriteLine(message);
			}
		}
    }
}
