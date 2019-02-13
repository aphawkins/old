//-----------------------------------------------------------------------
// <copyright file="CharCollectionToStringConverterUnitTests.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Unit tests for the associated class.</summary>
//-----------------------------------------------------------------------

namespace Useful.Wpf.Converters
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Unit tests for the CharCollectionToStringConverter class.
    /// </summary>
    [TestClass]
    public sealed class CharCollectionToStringConverterUnitTests
    {
        /// <summary>
        /// Tests conversion back of a char collection to a string.
        /// </summary>
        [TestMethod]
        public void ConvertBackCharCollectionToString()
        {
            CharCollectionToStringConverter converter = new CharCollectionToStringConverter();
            object result = converter.ConvertBack(null, typeof(ICollection<char>), "Hello World!", null);
            ICollection<char> chars = result as Collection<char>;
            Assert.AreEqual("Hello World!", new string(chars.ToArray()));
        }

        /// <summary>
        /// Tests conversion back of a char collection to a string using an incorrect type.
        /// </summary>
        [TestMethod]
        public void ConvertBackCharCollectionToStringIncorrectType()
        {
            CharCollectionToStringConverter converter = new CharCollectionToStringConverter();
            object result = converter.ConvertBack(null, typeof(ICollection<char>), Encoding.Unicode.GetBytes("Hello World!"), null);
            ICollection<char> chars = result as Collection<char>;
            Assert.AreEqual(0, chars.Count);
        }

        /// <summary>
        /// Tests conversion of a char collection to a string.
        /// </summary>
        [TestMethod]
        public void ConvertCharCollectionToString()
        {
            CharCollectionToStringConverter converter = new CharCollectionToStringConverter();
            object result = converter.Convert("Hello World!".ToCharArray(), typeof(string), null, null);
            Assert.AreEqual("Hello World!", result as string);
        }

        /// <summary>
        /// Tests conversion of a char collection to a string using an incorrect type.
        /// </summary>
        [TestMethod]
        public void ConvertCharCollectionToStringIncorrectType()
        {
            CharCollectionToStringConverter converter = new CharCollectionToStringConverter();
            object result = converter.Convert(Encoding.Unicode.GetBytes("Hello World!"), typeof(string), null, null);
            Assert.AreEqual(string.Empty, result as string);
        }
    }
}