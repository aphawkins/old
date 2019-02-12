using System;
using System.Collections.Generic;
using System.Text;

namespace Useful.Challenges
{
    /// <summary>
    /// A type for holding a single Su Doku box's data.
    /// </summary>
	public struct SudokuBox
	{
		private int minRow;
		private int maxRow;
		private int minCol;
		private int maxCol;

        /// <summary>
        /// The minimum row number in the Su Doku grid.
        /// </summary>
		public int MinRow
		{
			get { return this.minRow; }
			set { this.minRow = value; }
		}

        /// <summary>
        /// The maximum row number in the Su Doku grid.
        /// </summary>
		public int MaxRow
		{
			get { return this.maxRow; }
			set { this.maxRow = value; }
		}

        /// <summary>
        /// The minimum column number in the Su Doku grid.
        /// </summary>
		public int MinCol
		{
			get { return this.minCol; }
			set { this.minCol = value; }
		}

        /// <summary>
        /// The maximum column number in the Su Doku grid.
        /// </summary>
		public int MaxCol
		{
			get { return this.maxCol; }
			set { this.maxCol = value; }
		}

        /// <summary>
        /// Returns a value indicating whether this object's value is equal to another.
        /// </summary>
        /// <param name="operandX">This object.</param>
        /// <param name="operandY">The object to compare.</param>
        /// <returns>true if the objects are equal; otherwise false.</returns>
		public static bool operator ==(SudokuBox operandX, SudokuBox operandY)
		{
			return operandX == operandY;
		}

        /// <summary>
        /// Returns a value indicating whether this object's value is not equal to another.
        /// </summary>
        /// <param name="operandX">This object.</param>
        /// <param name="operandY">The object to compare.</param>
        /// <returns></returns>
		public static bool operator !=(SudokuBox operandX, SudokuBox operandY)
		{
			return operandX != operandY;
		}

		/// <summary>
		/// Returns a value indicating whether this instance is equal to another object.
		/// </summary>
		/// <param name="obj">The object to compare.</param>
		/// <returns>True if the objects are equal, else false.</returns>
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
	}
}
