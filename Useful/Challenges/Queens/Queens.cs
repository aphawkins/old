using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Useful.Challenges
{
    /// <summary>
    /// A class for solving the Queens chess problem.
    /// </summary>
	public class Queens
	{
		private struct Allowed
		{
			public bool[] Column;
			public bool[] Row;
			public bool[] Back;
			public bool[] Front;
		}
	
		#region Variables
		private int m_gridMax;
		private int[] m_result;
        private List<int[]> m_results;
		#endregion

		#region Constructor
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		public Queens()
		{
		}
		#endregion

		#region Methods
		/// <summary>
		/// Calculates all the positions of the queens in a grid.  Assumes the grid is a square and number of queens is equal to number of columns.
		/// </summary>
        /// <param name="gridSize">The size of the square grid.</param>
		/// <returns>Collection of results. Queen position is Row No = Result[Column#]</returns>
		public ReadOnlyCollection<int[]> Process(int gridSize)
		{
			m_gridMax = gridSize;
			
			m_result = new int[m_gridMax];
			m_results = new List<int[]>();

			Allowed allowed = new Allowed();
			allowed.Column = new bool[m_gridMax];
			allowed.Row = new bool[m_gridMax];
			allowed.Back = new bool[2 * m_gridMax - 1];
			allowed.Front = new bool[2 * m_gridMax - 1];

			Search(0, allowed);

			return new ReadOnlyCollection<int[]>(m_results);
		}
		
		private void Search(int Col, Allowed allowed)
		{
			// Go thru the columns
			for (int iCol = Col ; iCol < m_gridMax + 1 ; iCol++)
			{
				if (iCol == m_gridMax)
				{
					// Success!!!
					m_results.Add(m_result);
					m_result = (int[])m_result.Clone();
				}
				else
				{
					// Go thru the rows
					for (int iRow = 0 ; iRow < m_gridMax + 1 ; iRow++)
					{
						if (iRow == m_gridMax)
						{
							// Not in this column!!!
							m_result[iCol] = 0;
							return;
						}
						else
						{
							if (allowed.Back[iCol + iRow] == false 
								&& allowed.Front[iCol - iRow + m_gridMax - 1] == false 
								&& allowed.Row[iRow] == false)
							{
								Allowed allowedNew = new Allowed();

								allowedNew.Column = (bool[])allowed.Column.Clone();
								allowedNew.Row = (bool[])allowed.Row.Clone();
								allowedNew.Back = (bool[])allowed.Back.Clone();
								allowedNew.Front = (bool[])allowed.Front.Clone();

								allowedNew.Column[iCol] = true;
								allowedNew.Row[iRow] = true;
								allowedNew.Back[iCol + iRow] = true;
								allowedNew.Front[iCol - iRow + m_gridMax - 1] = true;

								m_result[iCol] = iRow;

								Search(iCol + 1, allowedNew);
							}
						}
					}
				}
			}
		}
		#endregion
	}
}
