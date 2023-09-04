namespace XMLTests
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Xsl;
    using Useful.Xml;

    public class XslTransformationUnitTests
    {
        [Fact]
        public void Transform()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "ws.xsl", false, true, string.Empty, new string[] { "unknown1=val", "unknown2=val", "unknown3=val", "unknown4=val" });

            Assert.Equal(response.Item1, GetDiff("tr1.xml"));
        }

        [Fact]
        public void Transform2()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "ws.xsl", true, true, string.Empty, new string[] { "unknown1=val", "unknown2=val", "unknown3=val", "unknown4=val" });

            Assert.Equal(response.Item1, GetDiff("tr2.xml"));
        }

        [Fact]
        public void Transform3()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "p1=first-name" });

            Assert.Equal(response.Item1, GetDiff("tr3.xml"));
        }

        [Fact]
        public void Transform4()
        {
            // Modified - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("valid.xml", "valid.xsl", false, true, string.Empty, new string[] { "p1=elem" });

            Assert.Equal(response.Item1, GetDiff("tr4.xml"));
        }

        [Fact]
        public void Transform5()
        {
            Tuple<string, XslTimings> response = RunTransformFile("invalid.xml", "copyof.xsl", false, true, string.Empty);

            Assert.Equal(response.Item1, GetDiff("tr5.xml"));
        }

        [Fact]
        public void Transform6()
        {
            // Modified - no mode
            Tuple<string, XslTimings> response = RunTransformFile("valid.xml", "valid_no_mode.xsl", false, true, string.Empty);

            Assert.Equal(response.Item1, GetDiff("tr6.xml"));
        }

        [Fact]
        public void Transform7()
        {
            // Modified - no mode - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("valid.xml", "valid_no_mode.xsl", false, true, string.Empty, new string[] { "xmlns:my-ns=http://my.com", "my-ns:param=val" });

            Assert.Equal(response.Item1, GetDiff("tr7.xml"));
        }

        [Fact]
        public void Transform8()
        {
            // Modified - no mode - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("valid.xml", "valid_no_mode.xsl", false, true, string.Empty, new string[] { "my-ns:param=val", "xmlns:my-ns=unknown", "xmlns:my-ns=http://my.com" });

            Assert.Equal(response.Item1, GetDiff("tr8.xml"));
        }

        [Fact]
        public void Transform9()
        {
            // Modified - no mode - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("valid.xml", "valid_no_mode.xsl", false, true, string.Empty, new string[] { "xmlns=http://my.com", "xmlns:my-ns2=http://my.com2", "my-ns2:param2=val2", "param=val" });

            Assert.Equal(response.Item1, GetDiff("tr9.xml"));
        }

        [Fact]
        public void Transform10()
        {
            // Modified - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "xmlns=http://my.com", "xmlns=", "p1=first-name", "p2=last-name", "p3=price", "p4=val4", "p5=val5" });

            Assert.Equal(response.Item1, GetDiff("tr10.xml"));
        }

        [Fact]
        public void Transform11()
        {
            // Modified - no mode - quotes removed
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid_no_mode.xsl", false, true, string.Empty, new string[] { "xmlns=http://my.com", "xmlns=", "xmlns=http://my.com", "xmlns:foo=unknown", "param=first-name" });

            Assert.Equal(response.Item1, GetDiff("tr11.xml"));
        }

        [Fact]
        public void Transform12()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "p1=first-name" });
            using (StreamReader xsl = new("copyof.xsl"))
            {
                response = RunTransformString(response.Item1, xsl.ReadToEnd(), false, true, string.Empty);
            }
            Assert.Equal(response.Item1, GetDiff("tr12.xml"));
        }

        [Fact]
        public void Transform13()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "copyof.xsl", false, true, string.Empty);

            Assert.Equal(response.Item1, GetDiff("tr13.xml"));
        }

        [Fact]
        public void Transform14()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "p1=last-name" });

            Assert.Equal(response.Item1, GetDiff("tr14.xml"));
        }

        // Require command line sort
        //[Fact]
        //public void Transform15()
        //{
        //	RunTest("{0} books.xml copyof10.xsl | more | {0} - copyof.xsl | sort > {1}\\tr15.xml ", (int)XsltError.None, "tr15.xml");
        //}

        // Require command line sort
        //[Fact]
        //public void Transform16()
        //{
        //	RunTest("{0} copyof.xsl copyof.xsl | {0} books.xml - | sort > {1}\\tr16.xml ", (int)XsltError.None, "tr16.xml");
        //}

        [Fact]
        public void Transform17()
        {
            // Modified - removed -u switch
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "version.xsl", false, true, string.Empty);

            Assert.Equal(response.Item1, GetDiff("tr17.xml"));
        }

        [Fact]
        public void Transform18()
        {
            // Modified - removed -u switch
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "version.xsl", false, true, string.Empty);

            Assert.Equal(response.Item1, GetDiff("tr18.xml"));
        }

        [Fact]
        public void Transform19()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", string.Empty, false, true, string.Empty);

            Assert.Equal(response.Item1, GetDiff("tr19.xml"));
        }

        [Fact]
        public void Transform20()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", string.Empty, false, true, string.Empty, new string[] { "p1=val" });

            Assert.Equal(response.Item1, GetDiff("tr20.xml"));
        }

        [Fact]
        public void Transform21()
        {
            Tuple<string, XslTimings> response = RunTransformFile("pi.xsl", string.Empty, false, true, string.Empty);

            Assert.Equal(response.Item1, GetDiff("tr21.xml"));
        }


        //[Fact]
        //public void TransformError()
        //{
        //    RunTransform("unknown.xml", "valid.xsl", false, false);
        //}

        //[Fact]
        //public void TransformError2()
        //{
        //    RunTransform("http://unknown/unknown.xml", "valid.xsl", false, false);
        //}

        /// <summary>
        /// XslLoadException expected
        /// </summary>
        [Fact]
        // [ExpectedException(typeof(XsltException))]  // Doesn't work for inherited exceptions!
        public void TransformError3()
        {
            try
            {
                _ = RunTransformFile("books.xml", "invalid1.xsl", false, true, string.Empty);
            }
            catch (XsltException)
            {
                return;
            }
            Assert.Fail();
        }

        [Fact]
        [ExpectedException(typeof(XmlException))]
        public void TransformError4()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "invalid2.xsl", false, true, string.Empty);

            Assert.Equal(response.Item1, GetDiff("trerr4.xml"));
        }

        //[Fact]
        //public void TransformError5()
        //{
        //    RunTest("books.xml valid.xsl -o \\unknown\\unknown\\unknown\\unknown.txt", (int)XsltError.MSXSL_E_CREATE_FILE_CTXT);
        //}

        [Fact]
        [ExpectedException(typeof(XmlException))]
        public void TransformError6()
        {
            _ = RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "!p!=val" });
        }

        [Fact]
        [ExpectedException(typeof(XmlException))]
        public void TransformError7()
        {
            _ = RunTransformFile("books.xml", "valid.xsl", false, true, string.Empty, new string[] { "xmlns:foo=http://my.com", "foo:bar:baz=val" });
        }

        [Fact]
        [ExpectedException(typeof(XsltException))]
        public void TransformError8()
        {
            _ = RunTransformFile("books.xml", "valid.xsl", false, true, "foo::=val", new string[] { "xmlns:foo=a" });
        }

        //[Fact]
        //public void TransformError9()
        //{
        //    RunTest("{0} -XW valid.xml copyof.xsl | sort | {0} - copyof.xsl", (int)XsltError.MSXSL_E_COMPILE_CTXT);
        //}

        [Fact]
        // [ExpectedException(typeof(XsltException))]  // Doesn't work for inherited exceptions!
        public void TransformError10()
        {
            Tuple<string, XslTimings> response = RunTransformFile("invalid1.xsl", "copyof.xsl", true, true, string.Empty);
            using (StreamReader xml = new("books.xml"))
            {
                try
                {
                    _ = RunTransformString(xml.ReadToEnd(), response.Item1, false, true, string.Empty);
                }
                catch (XsltException)
                {
                    return;
                }
            }
            Assert.Fail();
        }

        [Fact]
        [ExpectedException(typeof(XmlException))]
        public void TransformError11()
        {
            Tuple<string, XslTimings> response = RunTransformFile("invalid2.xsl", "copyof.xsl", true, true, string.Empty);
            using (StreamReader xml = new("books.xml"))
            {
                response = RunTransformString(xml.ReadToEnd(), response.Item1, false, true, string.Empty);
            }
            Assert.Equal(response.Item1, GetDiff("trerr11.xml"));
        }

        //[Fact]
        //public void TransformError12()
        //{
        //    RunTest("{0} -u 2.6 books.xml copyof.xsl", (int)XsltError.None);
        //}

        [Fact]
        [ExpectedException(typeof(XsltException))]
        public void TransformError13()
        {
            _ = RunTransformFile("copyof.xsl", null, false, true, string.Empty);
        }

        [Fact]
        [ExpectedException(typeof(XsltException))]
        public void TransformError14()
        {
            _ = RunTransformFile("bad-pi.xml", null, false, true, string.Empty);
        }

        [Fact]
        [ExpectedException(typeof(XsltException))]
        public void TransformError15()
        {
            _ = RunTransformFile("bad-pi2.xml", null, false, true, string.Empty);
        }

        [Fact]
        [ExpectedException(typeof(XsltException))]
        public void TransformError16()
        {
            _ = RunTransformFile("bad-pi3.xml", null, false, true, string.Empty);
        }

        [Fact]
        [ExpectedException(typeof(XmlException))]
        public void ResolutionError()
        {
            _ = RunTransformFile("invalid.xml", "copyof.xsl", false, false, string.Empty);
        }

        [Fact]
        public void Timings()
        {
            Tuple<string, XslTimings> response = RunTransformFile("books.xml", "valid.xsl", false, false, string.Empty);

            Assert.NotNull(response.Item2);
        }

        private static Tuple<string, XslTimings> RunTransformString(string xml, string xsl, bool removeWhitespace, bool externalDefinitions, string mode, params string[] parameters)
        {
            XslOptions options = new()
            {
                RemoveWhitespace = removeWhitespace,
                StartMode = mode,
                ExternalDefinitions = externalDefinitions
            };

            foreach (string s in parameters)
            {
                string name = s[..s.IndexOf('=')];
                string value = s[(s.IndexOf('=') + 1)..];

                options.AddParameter(name, value);
            }

            Tuple<string, XslTimings> response;
            if (string.IsNullOrEmpty(xsl))
            {
                // Use Processing Instruction
                response = XslTransformation.Transform(xml, options);
            }
            else
            {
                response = XslTransformation.Transform(xsl, xml, options);
            }

            return response;
        }

        private static Tuple<string, XslTimings> RunTransformFile(string xmlFile, string? xslFile, bool removeWhitespace, bool externalDefinitions, string mode, params string[] parameters)
        {
            string xml = File.ReadAllText(xmlFile);
            string xsl = string.IsNullOrEmpty(xslFile) ? string.Empty : File.ReadAllText(xslFile);

            return RunTransformString(xml, xsl, removeWhitespace, externalDefinitions, mode, parameters);
        }

        private static string GetDiff(string filename)
        {
            using StreamReader xml = new(Path.Combine(@"Useful\Tests\XsltTest\baseline", filename));
            return xml.ReadToEnd();
        }
    }
}
