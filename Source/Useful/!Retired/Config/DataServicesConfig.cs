using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.DataServices
{
    /// <summary>
    /// A structure for holding data services configuration.
    /// </summary>
	public struct DataServicesConfig : IConfig
	{
		internal string BasePath;
		internal string SchemaPath;
		internal string DatabaseConn;

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
		public static bool operator ==(DataServicesConfig operandX, DataServicesConfig operandY)
		{
			return ((operandX.BasePath == operandY.BasePath)
				&& (operandX.SchemaPath == operandY.SchemaPath)
				&& (operandX.DatabaseConn == operandY.DatabaseConn));
		}

        /// <summary>
        /// Returns a value indicating whether this object's value is not equal to another.
        /// </summary>
        /// <param name="operandX">This object.</param>
        /// <param name="operandY">The object to compare.</param>
        /// <returns></returns>
		public static bool operator !=(DataServicesConfig operandX, DataServicesConfig operandY)
		{
			return !(operandX == operandY);
		}
	}
}
