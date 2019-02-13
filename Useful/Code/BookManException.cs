
namespace BookMan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Globalization;

    [Serializable]
    public class BookManException : Exception
    {
        public BookManException() : base()
        {
        }

        public BookManException(string message)
            : base(message)
        {
        }

        public BookManException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        public BookManException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected BookManException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
