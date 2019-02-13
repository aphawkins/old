using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.DataServices
{
    /// <summary>
    /// A structure for holding file handling configuration.
    /// </summary>
	public struct FilesConfig : IConfig
	{
		internal string ImportPath;
		internal string ExportPath;
		internal string ErrorPath;
		internal int TimeOut; // in milliseconds
		internal string Filter;

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
		public static bool operator ==(FilesConfig operandX, FilesConfig operandY)
		{
			return ((operandX.ImportPath == operandY.ImportPath)
				&& (operandX.ExportPath == operandY.ExportPath)
				&& (operandX.ErrorPath == operandY.ErrorPath)
				&& (operandX.TimeOut == operandY.TimeOut)
				&& (operandX.Filter == operandY.Filter));
		}

        /// <summary>
        /// Returns a value indicating whether this object's value is not equal to another.
        /// </summary>
        /// <param name="operandX">This object.</param>
        /// <param name="operandY">The object to compare.</param>
        /// <returns></returns>
		public static bool operator !=(FilesConfig operandX, FilesConfig operandY)
		{
            return !(operandX == operandY);
		}
	}
}
