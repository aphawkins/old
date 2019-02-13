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
	public class XslTransformationUnitTests
	{
		[TestInitialize()]
		public void TestInitialize()
		{
		}

		[TestMethod]
		public void Transform()
		{
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "ws.xsl", false, true, string.Empty, new string[] { "unknown1=val", "unknown2=val", "unknown3=val", "unknown4=val" });

            Assert.AreEqual(response.Item1, GetDiff("tr1.xml"));
		}

		[TestMethod]
		public void Transform2()
		{
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "ws.xsl", true, true, string.Empty, new string[] { "unknown1=val", "unknown2=val", "unknown3=val", "unknown4=val" });

            Assert.AreEqual(response.Item1, GetDiff("tr2.xml"));
		}

        [TestMethod]
        public void Transform3()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "p1=first-name" });

            Assert.AreEqual(response.Item1, GetDiff("tr3.xml"));
        }

        [TestMethod]
        public void Transform4()
        {
			// Modified - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("valid.xml", "valid.xsl", false, true, string.Empty, new string[] { "p1=elem" });

            Assert.AreEqual(response.Item1, GetDiff("tr4.xml"));
        }

		[TestMethod]
		public void Transform5()
		{
            Tuple<string, XslTimings> response = RunTransformFile("invalid.xml", "copyof.xsl", false, true, string.Empty);

            Assert.AreEqual(response.Item1, GetDiff("tr5.xml"));
		}

		[TestMethod]
		public void Transform6()
		{
			// Modified - no mode
            Tuple<string, XslTimings> response = RunTransformFile("valid.xml", "valid_no_mode.xsl", false, true, string.Empty);

            Assert.AreEqual(response.Item1, GetDiff("tr6.xml"));
		}

        [TestMethod]
        public void Transform7()
        {
            // Modified - no mode - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("valid.xml", "valid_no_mode.xsl", false, true, string.Empty, new string[] { "xmlns:my-ns=http://my.com", "my-ns:param=val" });

            Assert.AreEqual(response.Item1, GetDiff("tr7.xml"));
        }

        [TestMethod]
        public void Transform8()
        {
            // Modified - no mode - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("valid.xml", "valid_no_mode.xsl", false, true, string.Empty, new string[] { "my-ns:param=val", "xmlns:my-ns=unknown", "xmlns:my-ns=http://my.com" });

            Assert.AreEqual(response.Item1, GetDiff("tr8.xml"));
        }

        [TestMethod]
        public void Transform9()
        {
            // Modified - no mode - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("valid.xml", "valid_no_mode.xsl", false, true, string.Empty, new string[] { "xmlns=http://my.com", "xmlns:my-ns2=http://my.com2", "my-ns2:param2=val2", "param=val" });

            Assert.AreEqual(response.Item1, GetDiff("tr9.xml"));
        }

        [TestMethod]
        public void Transform10()
        {
            // Modified - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "xmlns=http://my.com", "xmlns=", "p1=first-name", "p2=last-name", "p3=price", "p4=val4", "p5=val5" });

            Assert.AreEqual(response.Item1, GetDiff("tr10.xml"));
        }

        [TestMethod]
        public void Transform11()
        {
            // Modified - no mode - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid_no_mode.xsl", false, true, string.Empty, new string[] { "xmlns=http://my.com", "xmlns=", "xmlns=http://my.com", "xmlns:foo=unknown", "param=first-name" });

            Assert.AreEqual(response.Item1, GetDiff("tr11.xml"));
        }

		[TestMethod]
		public void Transform12()
		{
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "p1=first-name" });
            using (StreamReader xsl = new StreamReader("copyof.xsl"))
            {
                response = RunTransformString(response.Item1, xsl.ReadToEnd(), false, true, string.Empty);
            }
            Assert.AreEqual(response.Item1, GetDiff("tr12.xml"));
		}

		[TestMethod]
		public void Transform13()
		{
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "copyof.xsl", false, true, string.Empty);

            Assert.AreEqual(response.Item1, GetDiff("tr13.xml"));
		}

        [TestMethod]
        public void Transform14()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "p1=last-name" });

            Assert.AreEqual(response.Item1, GetDiff("tr14.xml"));
        }

		// Require command line sort
		//[TestMethod]
		//public void Transform15()
		//{
		//	RunTest("{0} books.xml copyof10.xsl | more | {0} - copyof.xsl | sort > {1}\\tr15.xml ", (int)XsltError.None, "tr15.xml");
		//}

		// Require command line sort
		//[TestMethod]
		//public void Transform16()
		//{
		//	RunTest("{0} copyof.xsl copyof.xsl | {0} books.xml - | sort > {1}\\tr16.xml ", (int)XsltError.None, "tr16.xml");
		//}

        [TestMethod]
        public void Transform17()
        {
            // Modified - removed -u switch
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "version.xsl", false, true, string.Empty);

            Assert.AreEqual(response.Item1, GetDiff("tr17.xml"));
        }

        [TestMethod]
        public void Transform18()
        {
            // Modified - removed -u switch
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "version.xsl", false, true, string.Empty);

            Assert.AreEqual(response.Item1, GetDiff("tr18.xml"));
        }

        [TestMethod]
        public void Transform19()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", string.Empty, false, true, string.Empty);

            Assert.AreEqual(response.Item1, GetDiff("tr19.xml"));
        }

        [TestMethod]
        public void Transform20()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", string.Empty, false, true, string.Empty, new string[] { "p1=val" });

            Assert.AreEqual(response.Item1, GetDiff("tr20.xml"));
        }

        [TestMethod]
        public void Transform21()
        {
            Tuple<string, XslTimings> response = RunTransformFile("pi.xsl", string.Empty, false, true, string.Empty);

            Assert.AreEqual(response.Item1, GetDiff("tr21.xml"));
        }


        //[TestMethod]
        //public void TransformError()
        //{
        //    RunTransform("unknown.xml", "valid.xsl", false, false);
        //}

        //[TestMethod]
        //public void TransformError2()
        //{
        //    RunTransform("http://unknown/unknown.xml", "valid.xsl", false, false);
        //}

        /// <summary>
        /// XslLoadException expected
        /// </summary>
        [TestMethod]
        // [ExpectedException(typeof(XsltException))]  // Doesn't work for inherited exceptions!
        public void TransformError3()
        {
            try
            {
                RunTransformFile("books.xml", "invalid1.xsl", false, true, string.Empty);
            }
            catch (XsltException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void TransformError4()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "invalid2.xsl", false, true, string.Empty);

            Assert.AreEqual(response.Item1, GetDiff("trerr4.xml"));
        }

        //[TestMethod]
        //public void TransformError5()
        //{
        //    RunTest("books.xml valid.xsl -o \\unknown\\unknown\\unknown\\unknown.txt", (int)XsltError.MSXSL_E_CREATE_FILE_CTXT);
        //}

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void TransformError6()
        {
            RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "!p!=val" });
        }

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void TransformError7()
        {
            RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "xmlns:foo=http://my.com", "foo:bar:baz=val" });
        }

        [TestMethod]
        [ExpectedException(typeof(XsltException))]
        public void TransformError8()
        {
            RunTransformFile("books.xml", "valid.xsl", false, true, "foo::=val", new string[] { "xmlns:foo=a" });
        }

        //[TestMethod]
        //public void TransformError9()
        //{
        //    RunTest("{0} -XW valid.xml copyof.xsl | sort | {0} - copyof.xsl", (int)XsltError.MSXSL_E_COMPILE_CTXT);
        //}

        [TestMethod]
        // [ExpectedException(typeof(XsltException))]  // Doesn't work for inherited exceptions!
        public void TransformError10()
        {
            Tuple<string, XslTimings> response = RunTransformFile("invalid1.xsl", "copyof.xsl", true, true, string.Empty);
            using (StreamReader xml = new StreamReader("books.xml"))
            {
                try
                {
                    RunTransformString(xml.ReadToEnd(), response.Item1, false, true, string.Empty);
                }
                catch (XsltException)
                {
                    return;
                }
            }
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void TransformError11()
        {
            Tuple<string, XslTimings> response = RunTransformFile("invalid2.xsl", "copyof.xsl", true, true, string.Empty);
            using (StreamReader xml = new StreamReader("books.xml"))
            {
                response = RunTransformString(xml.ReadToEnd(), response.Item1, false, true, string.Empty);
            }
            Assert.AreEqual(response.Item1, GetDiff("trerr11.xml"));
        }

        //[TestMethod]
        //public void TransformError12()
        //{
        //    RunTest("{0} -u 2.6 books.xml copyof.xsl", (int)XsltError.None);
        //}

        [TestMethod]
        [ExpectedException(typeof(XsltException))]
        public void TransformError13()
        {
            RunTransformFile("copyof.xsl", null, false, true, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(XsltException))]
        public void TransformError14()
        {
            RunTransformFile("bad-pi.xml", null, false, true, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(XsltException))]
        public void TransformError15()
        {
            RunTransformFile("bad-pi2.xml", null, false, true, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(XsltException))]
        public void TransformError16()
        {
            RunTransformFile("bad-pi3.xml", null, false, true, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void ResolutionError()
        {
            RunTransformFile("invalid.xml", "copyof.xsl", false, false, string.Empty);
        }

        [TestMethod]
        public void Timings()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid.xsl", false, false, string.Empty);

            Assert.IsNotNull(response.Item2);
        }

        private static Tuple<string, XslTimings> RunTransformString(string xml, string xsl, bool removeWhitespace, bool externalDefinitions, string mode, params string[] parameters)
        {
            XslOptions options = new XslOptions();
            options.RemoveWhitespace = removeWhitespace;
            options.StartMode = mode;
            options.ExternalDefinitions = externalDefinitions;

            foreach (string s in parameters)
            {
                string name = s.Substring(0, s.IndexOf('='));
                string value = s.Substring(s.IndexOf('=') + 1);

                options.AddParameter(name, value);
            }

            Tuple<string, XslTimings> response;
            if (string.IsNullOrEmpty(xsl))
            {
                // Use Processing Instruction
                response = Useful.Xml.XslTransformation.Transform(xml, options);
            }
            else
            {
                response = Useful.Xml.XslTransformation.Transform(xsl, xml, options);
            }

            return response;
        }

        private static Tuple<string, XslTimings> RunTransformFile(string xmlFile, string xslFile, bool removeWhitespace, bool externalDefinitions, string mode, params string[] parameters)
        {
            string xml = File.ReadAllText(xmlFile);
            string xsl = string.IsNullOrEmpty(xslFile) ? string.Empty : File.ReadAllText(xslFile);

            return RunTransformString(xml, xsl, removeWhitespace, externalDefinitions, mode, parameters);
        }

        private static string GetDiff(string filename)
        {
            using (StreamReader xml = new StreamReader(Path.Combine(@"Useful\Tests\XsltTest\baseline", filename)))
            {
                return xml.ReadToEnd();
            }
        }
    }
}
