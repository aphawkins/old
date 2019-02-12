//-----------------------------------------------------------------------
// <copyright file="StringWriterWithEncoding.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>A StringWriter that is encoding aware.</summary>
//-----------------------------------------------------------------------

namespace Useful.IO
{
	using System;
	using System.Diagnostics.Contracts;
	using System.Globalization;
	using System.IO;
	using System.Text;

	/// <summary>
	/// A simple class derived from StringWriter, but which allows the user to select which Encoding is used. 
	/// This is most likely to be used with XmlTextWriter, which uses the Encoding property to determine which encoding to specify in the XML. 
	/// </summary>
	internal class StringWriterWithEncoding : StringWriter
	{
		// Fields
		private Encoding encoding;

		// Methods
		public StringWriterWithEncoding(Encoding encoding)
			: this(CultureInfo.InvariantCulture, encoding)
		{
			Contract.Requires(encoding != null);
		}

		public StringWriterWithEncoding(IFormatProvider formatProvider, Encoding encoding)
			: base(formatProvider)
		{
			Contract.Requires(formatProvider != null);
			Contract.Requires(encoding != null);
			this.SetEncoding(encoding);
		}

		public StringWriterWithEncoding(StringBuilder sb, Encoding encoding)
			: this(sb, CultureInfo.InvariantCulture, encoding)
		{
			Contract.Requires(sb != null);
			Contract.Requires(encoding != null);
		}

		public StringWriterWithEncoding(StringBuilder sb, IFormatProvider formatProvider, Encoding encoding)
			: base(sb, formatProvider)
		{
			Contract.Requires(sb != null);
			Contract.Requires(formatProvider != null);
			Contract.Requires(encoding != null);

			this.SetEncoding(encoding);
		}

		// Properties
		public override Encoding Encoding
		{
			get
			{
                Contract.Ensures(Contract.Result<Encoding>() != null);
                Contract.Assume(this.encoding != null);
				return this.encoding;
			}
		}

		private void SetEncoding(Encoding encodingToUse)
		{
			Contract.Requires(encodingToUse != null);

			if (encodingToUse == null)
			{
				this.encoding = new UTF8Encoding(false);
				return;
			}

			this.encoding = encodingToUse;
		}
	}
}
