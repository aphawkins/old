//-----------------------------------------------------------------------
// <copyright file="XmlValidationException.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Exception that is raised if there is an XmlValidation error.</summary>
//-----------------------------------------------------------------------

namespace Useful.Xml
{
	using System;
	using System.Runtime.Serialization;

	[Serializable]
	public class XmlValidationException : Exception
	{
		public XmlValidationException()
		{
		}

		public XmlValidationException(string message)
			: base(message)
		{
		}

		public XmlValidationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
		
		protected XmlValidationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}