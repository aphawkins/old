using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.DataServices
{
    /// <summary>
    /// A structure for holding message queue handling configuration.
    /// </summary>
	public struct QueuesConfig : IConfig
	{
		private string m_import;
		private string m_export;
		private string m_errors;

        /// <summary>
        /// Gets or sets the import queue.
        /// </summary>
		public string Import
		{
			get { return m_import; }
			set { m_import = value; }
		}

        /// <summary>
        /// Gets or sets the export queue.
        /// </summary>
		public string Export
		{
			get { return m_export; }
			set { m_export = value; }
		}

        /// <summary>
        /// Gets or sets the errors queue.
        /// </summary>
		public string Errors
		{
			get { return m_errors; }
			set { m_errors = value; }
		}

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
		public static bool operator ==(QueuesConfig operandX, QueuesConfig operandY)
		{
			return ((operandX.Import == operandY.Import)
				&& (operandX.Export == operandY.Export)
				&& (operandX.Errors == operandY.Errors));
		}

        /// <summary>
        /// Returns a value indicating whether this object's value is not equal to another.
        /// </summary>
        /// <param name="operandX">This object.</param>
        /// <param name="operandY">The object to compare.</param>
        /// <returns></returns>
		public static bool operator !=(QueuesConfig operandX, QueuesConfig operandY)
		{
			return !(operandX == operandY);
		}
	}
}
