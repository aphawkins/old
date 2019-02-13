using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Useful.Config
{
    /// <summary>
    /// The exception that is thrown when a data service error occurs.
    /// </summary>
	[Serializable]
	public class ConfigurationException : Exception
	{
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		public ConfigurationException()
			: base()
		{
		}

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="message">The error message.</param>
		public ConfigurationException(string message)
			: base(message)
		{
		}

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">A previous error.</param>
        public ConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="info">Stores all the data needed to serialize or deserialize an object.</param>
        /// <param name="context">Describes the source and destination of a given serialized stream, and provides an additional caller-defined context.</param>
        protected ConfigurationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}

