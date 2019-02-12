using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.DataServices
{
    /// <summary>
    /// A structure for holding subscription handling configuration.
    /// </summary>
	public struct SubsConfig : IConfig
	{
		internal string DatabaseConn;
		internal int TimeOut;  // in milliseconds

        /// <summary>
        /// Returns a value indicating whether this instance is equal to another object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns></returns>
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

        /// <summary>
        /// Retrieves a value that indicates the hash code value for this object.
        /// </summary>
        /// <returns>The hash code value for this object.</returns>
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

        /// <summary>
        /// Returns a value indicating whether this object's value is equal to another.
        /// </summary>
        /// <param name="operandX">This object.</param>
        /// <param name="operandY">The object to compare.</param>
        /// <returns></returns>
		public static bool operator ==(SubsConfig operandX, SubsConfig operandY)
		{
			return ((operandX.DatabaseConn == operandY.DatabaseConn)
				&& (operandX.TimeOut == operandY.TimeOut));
		}

        /// <summary>
        /// Returns a value indicating whether this object's value is not equal to another.
        /// </summary>
        /// <param name="operandX">This object.</param>
        /// <param name="operandY">The object to compare.</param>
        /// <returns></returns>
		public static bool operator !=(SubsConfig operandX, SubsConfig operandY)
		{
			return !(operandX == operandY);
		}
	}
}
