// <copyright file="EncodingStreamUnitTests.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Tests the encoding stream class.</summary>
//-----------------------------------------------------------------------

namespace Useful.Security.Cryptography
{
    using IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    /// <summary>
    /// This is a test class for EncodingStream and is intended to contain all the Unit Tests.
    /// </summary>
    [TestClass]
    [DebuggerDisplay("{ToString()}")]
    public sealed class EncodingStreamUnitTests
    {
        /// <summary>
        /// Test dispose.
        /// </summary>
        [TestMethod]
        public void EncodingStream_Dispose()
        {
            using (MemoryStream input = new MemoryStream())
            {
                EncodingStream target = new EncodingStream(input, Encoding.ASCII, Encoding.UTF8);
                target.Dispose();
            }
        }

        /// <summary>
        /// Test dispose after the object has been disposed.
        /// </summary>
        [TestMethod]
        public void EncodingStream_Double_Dispose()
        {
            using (MemoryStream input = new MemoryStream())
            {
                EncodingStream target = new EncodingStream(input, Encoding.ASCII, Encoding.UTF8);
                target.Dispose();
                target.Dispose();
            }
        }

        /// <summary>
        /// Test reading from the stream - same encoding.
        /// </summary>
        [TestMethod]
        public void EncodingStream_Read_Same_Encoding()
        {
            using (MemoryStream input = new MemoryStream())
            {
                Encoding from = Encoding.Unicode;
                Encoding to = Encoding.Unicode;
                string test = "Hello World";

                byte[] fromBytes = from.GetBytes(test);
                byte[] toBytes = new byte[to.GetBytes(test).Length];

                EncodingStream target = new EncodingStream(input, from, to);

                target.Write(fromBytes, 0, fromBytes.Length);
                target.Flush();
                target.Position = to.GetPreamble().Length;

                Assert.AreEqual(target.Length, to.GetPreamble().Length + toBytes.Length);
                Assert.AreEqual(toBytes.Length, target.Read(toBytes, 0, toBytes.Length));
                Assert.AreEqual(test, to.GetString(toBytes));
            }
        }

        /// <summary>
        /// Test reading from the stream - changing the encoding.
        /// </summary>
        [TestMethod]
        public void EncodingStream_Read_Change_Encoding()
        {
            using (MemoryStream input = new MemoryStream())
            {
                Encoding from = Encoding.Unicode;
                Encoding to = Encoding.UTF8;
                string test = "Hello World";

                byte[] fromBytes = from.GetBytes(test);
                byte[] toBytes = new byte[to.GetBytes(test).Length];

                EncodingStream target = new EncodingStream(input, from, to);

                target.Write(fromBytes, 0, fromBytes.Length);
                target.Position = to.GetPreamble().Length;

                Assert.AreEqual(target.Length, to.GetPreamble().Length + toBytes.Length);
                Assert.AreEqual(toBytes.Length, target.Read(toBytes, 0, toBytes.Length));
                Assert.AreEqual(test, to.GetString(toBytes));
            }
        }

        /// <summary>
        /// Test reading using a null buffer.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodingStream_Read_Null_Buffer()
        {
            using (MemoryStream input = new MemoryStream())
            {
                EncodingStream target = new EncodingStream(input, Encoding.Unicode, Encoding.UTF8);
                target.Read(null, 0, 1);
            }
        }

        /// <summary>
        /// Test ability to read.
        /// </summary>
        [TestMethod]
        public void EncodingStream_CanRead()
        {
            using (MemoryStream input = new MemoryStream())
            {
                EncodingStream target = new EncodingStream(input, Encoding.Unicode, Encoding.UTF8);
                Assert.IsTrue(target.CanRead);
            }
        }

        /// <summary>
        /// Test ability to write.
        /// </summary>
        [TestMethod]
        public void EncodingStream_CanWrite()
        {
            using (MemoryStream input = new MemoryStream())
            {
                EncodingStream target = new EncodingStream(input, Encoding.Unicode, Encoding.UTF8);
                Assert.IsTrue(target.CanWrite);
            }
        }

        /// <summary>
        /// Test ability to seek.
        /// </summary>
        [TestMethod]
        public void EncodingStream_CanSeek()
        {
            using (MemoryStream input = new MemoryStream())
            {
                EncodingStream target = new EncodingStream(input, Encoding.Unicode, Encoding.UTF8);
                Assert.IsTrue(target.CanSeek);
            }
        }

        /// <summary>
        /// Test writing using a null buffer.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EncodingStream_Write_Null_Buffer()
        {
            using (MemoryStream input = new MemoryStream())
            {
                EncodingStream target = new EncodingStream(input, Encoding.Unicode, Encoding.UTF8);
                target.Write(null, 0, 1);
            }
        }

        /// <summary>
        /// Test reading from the stream - changing the encoding.
        /// </summary>
        [TestMethod]
        public void EncodingStream_Seek()
        {
            using (MemoryStream input = new MemoryStream())
            {
                Encoding from = Encoding.Unicode;

                byte[] fromBytes = from.GetBytes("Hello World");

                EncodingStream target = new EncodingStream(input, from, Encoding.UTF8);

                target.Write(fromBytes, 0, fromBytes.Length);
                target.Seek(2, SeekOrigin.Begin);

                Assert.AreEqual(2, target.Position);
            }
        }

        /// <summary>
        /// Test reading from the stream - changing the encoding.
        /// </summary>
        [TestMethod]
        public void EncodingStream_SetLength()
        {
            using (MemoryStream input = new MemoryStream())
            {
                Encoding from = Encoding.Unicode;

                byte[] fromBytes = from.GetBytes("Hello World");

                EncodingStream target = new EncodingStream(input, from, Encoding.UTF8);

                target.Write(fromBytes, 0, fromBytes.Length);
                target.SetLength(50);

                Assert.AreEqual(50, target.Length);
            }
        }
    }
}