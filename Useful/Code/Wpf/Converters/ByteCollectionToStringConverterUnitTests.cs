//-----------------------------------------------------------------------
// <copyright file="ByteCollectionToStringConverterUnitTests.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Unit tests for the associated class.</summary>
//-----------------------------------------------------------------------

namespace Useful.Wpf.Converters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Unit tests for the ByteCollectionToStringConverter class.
    /// </summary>
    [TestClass]
    public sealed class ByteCollectionToStringConverterUnitTests
    {
        /// <summary>
        /// Tests conversion of a byte collection to a string.
        /// </summary>
        [TestMethod]
        public void ConvertByteCollectionToString()
        {
            ByteCollectionToStringConverter converter = new ByteCollectionToStringConverter();
            object result = converter.Convert(Encoding.Unicode.GetBytes("Hello World!"), typeof(string), null, null);
            Assert.AreEqual("Hello World!", result as string);
        }

        /// <summary>
        /// Tests conversion of a byte collection to a string using an incorrect type.
        /// </summary>
        [TestMethod]
        public void ConvertByteCollectionToStringIncorrectType()
        {
            ByteCollectionToStringConverter converter = new ByteCollectionToStringConverter();
            object result = converter.Convert(123456, typeof(string), null, null);
            Assert.AreEqual(string.Empty, result as string);
        }

        /// <summary>
        /// Tests conversion back of a byte collection to a string.
        /// </summary>
        [TestMethod]
        public void ConvertBackByteCollectionToString()
        {
            ByteCollectionToStringConverter converter = new ByteCollectionToStringConverter();
            object result = converter.ConvertBack(null, typeof(ICollection<byte>), "Hello World!", null);
            ICollection<byte> bytes = result as ICollection<byte>;
            Assert.AreEqual("Hello World!", Encoding.Unicode.GetString(bytes.ToArray()));
        }

        /// <summary>
        /// Tests conversion back of a byte collection to a string using an incorrect type.
        /// </summary>
        [TestMethod]
        public void ConvertBackByteCollectionToStringIncorrectType()
        {
            ByteCollectionToStringConverter converter = new ByteCollectionToStringConverter();
            object result = converter.ConvertBack(null, typeof(ICollection<byte>), 123456, null);
            ICollection<byte> bytes = result as ICollection<byte>;
            Assert.AreEqual(0, bytes.Count);
        }
    }
}