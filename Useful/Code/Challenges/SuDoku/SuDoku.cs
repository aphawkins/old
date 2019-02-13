using System;
using System.Collections.Generic;
using System.Resources;
using System.Reflection;
using System.Globalization;

using Useful.Challenges;

namespace Useful.Challenges
{
    /// <summary>
    /// A class for solving the Su Doku puzzle.
    /// </summary>
	public class Sudoku
	{
		#region Variables
		private int[][] grid;
		private bool[][][] allowedValues;
		private SudokuBox[] boxes;
		#endregion

		#region Constructors
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		private Sudoku()
		{
			InitializeBoxes();
		}

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		public Sudoku(int[][] grid) : this()
		{
			InitializeGrid();
			InitializeAllowedValues();
			ProcessGrid(grid);
		}

        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		protected internal Sudoku(bool[][][] allowedValues, int[][] grid) : this()
		{
			this.allowedValues = allowedValues;
			this.grid = grid;
		}
		#endregion

		#region Methods
        /// <summary>
        /// Gets the Su Doku grid.
        /// </summary>
		public int[][] GetGrid()
		{
			return this.grid;
		}

		#region Initialize
		private void InitializeGrid()
		{
			this.grid = new int[9][];
			for (int i = 0; i < 9; i++)
			{
				this.grid[i] = new int[9];
			}
		}

		private void InitializeBoxes()
		{
			this.boxes = new SudokuBox[9];
			this.boxes[0].MinRow = this.boxes[1].MinRow = this.boxes[2].MinRow = 0;
			this.boxes[0].MaxRow = this.boxes[1].MaxRow = this.boxes[2].MaxRow = 2;
			this.boxes[3].MinRow = this.boxes[4].MinRow = this.boxes[5].MinRow = 3;
			this.boxes[3].MaxRow = this.boxes[4].MaxRow = this.boxes[5].MaxRow = 5;
			this.boxes[6].MinRow = this.boxes[7].MinRow = this.boxes[8].MinRow = 6;
			this.boxes[6].MaxRow = this.boxes[7].MaxRow = this.boxes[8].MaxRow = 8;

			this.boxes[0].MinCol = this.boxes[3].MinCol = this.boxes[6].MinCol = 0;
			this.boxes[0].MaxCol = this.boxes[3].MaxCol = this.boxes[6].MaxCol = 2;
			this.boxes[1].MinCol = this.boxes[4].MinCol = this.boxes[7].MinCol = 3;
			this.boxes[1].MaxCol = this.boxes[4].MaxCol = this.boxes[7].MaxCol = 5;
			this.boxes[2].MinCol = this.boxes[5].MinCol = this.boxes[8].MinCol = 6;
			this.boxes[2].MaxCol = this.boxes[5].MaxCol = this.boxes[8].MaxCol = 8;
		}

		private void InitializeAllowedValues()
		{
			this.allowedValues = new bool[9][][];
			for (int row = 0; row < 9; row++)
			{
				this.allowedValues[row] = new bool[9][];
				for (int col = 0; col < 9; col++)
				{
					this.allowedValues[row][col] = new bool[9];
					for (int i = 0; i < 9; i++)
					{
						this.allowedValues[row][col][i] = true;
					}
				}
			}
		}

		private void ProcessGrid(int[][] newGrid)
		{
			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++)
				{
					NumberFound(row, col, newGrid[row][col] - 1);
				}
			}
		}
		#endregion

		private void NumberFound(int row, int col, int number)
		{
			// A zero (blank) in the initial grid
			if (number == -1)
			{
				return;
			}
			if (number < 0 || number > 8)
			{
				throw new ArgumentException(Resource.NumberOutOfRangeMessage, "number");
			}

			this.grid[row][col] = number + 1;

			// Remove number from its row
			for (int rowNum = 0; rowNum < 9; rowNum++)
			{
				this.allowedValues[rowNum][col][number] = false;
			}
			// Remove number from its column
			for (int colNum = 0; colNum < 9; colNum++)
			{
				this.allowedValues[row][colNum][number] = false;
			}
			// Remove number from its grid
			int gridNum = GetGridNum(row, col);
			for (int rowNum = this.boxes[gridNum].MinRow; rowNum <= this.boxes[gridNum].MaxRow; rowNum++)
			{
				for (int colNum = this.boxes[gridNum].MinCol; colNum <= this.boxes[gridNum].MaxCol; colNum++)
				{
					this.allowedValues[rowNum][colNum][number] = false;
				}
			}
			// It's square can't be any other number
			for (int i = 0; i < 9; i++)
			{
				this.allowedValues[row][col][i] = false;
			}

			return;
		}

		private int GetGridNum(int row, int col)
		{
			for (int i = 0; i < 9; i++)
			{
				if (this.boxes[i].MinRow <= row
					&& this.boxes[i].MaxRow >= row
					&& this.boxes[i].MinCol <= col
					&& this.boxes[i].MaxCol >= col)
				{
					return i;
				}
			}
			// Something went wrong!
			return -1;
		}

		#region Solving
        /// <summary>
        /// Solve this So Doku puzzle.
        /// </summary>
        /// <returns></returns>
		public bool Solve()
		{
			bool numberFound = false;

			do
			{
				numberFound = false;
				numberFound |= TryLoneSquareNumber();
				numberFound |= TryLoneRowNumber();
				numberFound |= TryLoneColumnNumber();
				numberFound |= TryLoneBoxNumber();
				// Add other tests here
			}
			while (numberFound);

			if (IsSolved())
			{
				return true;
			}
			else
			{
				return TryRecursion();
			}
		}

		/// <summary>
		/// A lone number is a one remaining allowed number in a square.
		/// </summary>
		/// <returns></returns>
		private bool TryLoneSquareNumber()
		{
			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++)
				{
					int loneNumber = -1;
					bool loneNumberFound = false;

					for (int i = 0; i < 9; i++)
					{
						if (this.allowedValues[row][col][i])
						{
							if (loneNumberFound)
							{
								// Not a lone number
								loneNumberFound = false;
								break;
							}
							else
							{
								loneNumberFound = true;
								loneNumber = i;
							}
						}
					}
					if (loneNumberFound)
					{
						NumberFound(row, col, loneNumber);
						return true;
					}
				}
			}
			return false;
		}

		private bool TryLoneRowNumber()
		{
			for (int i = 0; i < 9; i++)
			{
				for (int row = 0; row < 9; row++)
				{
					int loneNumberCol = -1;
					bool loneNumberFound = false;

					for (int col = 0; col < 9; col++)
					{
						if (this.allowedValues[row][col][i])
						{
							if (loneNumberFound)
							{
								// Not a lone number
								loneNumberFound = false;
								break;
							}
							else
							{
								loneNumberFound = true;
								loneNumberCol = col;
							}
						}
					}
					if (loneNumberFound)
					{
						NumberFound(row, loneNumberCol, i);
						return true;
					}
				}
			}
			return false;
		}

		private bool TryLoneColumnNumber()
		{
			for (int i = 0; i < 9; i++)
			{
				for (int col = 0; col < 9; col++)
				{
					int loneNumberRow = -1;
					bool loneNumberFound = false;

					for (int row = 0; row < 9; row++)
					{
						if (this.allowedValues[row][col][i])
						{
							if (loneNumberFound)
							{
								// Not a lone number
								loneNumberFound = false;
								break;
							}
							else
							{
								loneNumberFound = true;
								loneNumberRow = row;
							}
						}
					}
					if (loneNumberFound)
					{
						NumberFound(loneNumberRow, col, i);
						return true;
					}
				}
			}
			return false;
		}

		private bool TryLoneBoxNumber()
		{
			for (int num = 0; num < 9; num++)
			{
				for (int box = 0; box < 9; box++)
				{
					int loneNumberRow = -1;
					int loneNumberCol = -1;
					bool loneNumberFound = false;
					bool abort = false;

					for (int row = this.boxes[box].MinRow; row <= this.boxes[box].MaxRow; row++)
					{
						for (int col = this.boxes[box].MinCol; col <= this.boxes[box].MaxCol; col++)
						{
							if (this.allowedValues[row][col][num])
							{
								if (loneNumberFound)
								{
									// Not a lone number
									loneNumberFound = false;
									abort = true;
									break;
								}
								else
								{
									loneNumberFound = true;
									loneNumberRow = row;
									loneNumberCol = col;
								}
							}
						}
						if (abort)
						{
							break;
						}
					}
					if (loneNumberFound)
					{
						NumberFound(loneNumberRow, loneNumberCol, num);
						return true;
					}
				}
			}
			return false;
		}

		private bool IsSolved()
		{
			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++)
				{
					if (this.grid[row][col] == 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		private bool TryRecursion()
		{

			for (int row = 0; row < 9; row++)
			{
				for (int col = 0; col < 9; col++)
				{
					for (int i = 0; i < 9; i++)
					{
						if (this.allowedValues[row][col][i])
						{
							int[][] gr = new int[9][];
							bool[][][] all = new bool[9][][];

							for (int x = 0; x < 9; x++)
							{
								gr[x] = new int[9];
								this.grid[x].CopyTo(gr[x], 0);

								all[x] = new bool[9][];

								for (int y = 0; y < 9; y++)
								{
									all[x][y] = new bool[9];
									this.allowedValues[x][y].CopyTo(all[x][y], 0);
								}
							}

							Sudoku sudoku = new Sudoku(all, gr);
							sudoku.NumberFound(row, col, i);
							bool isSolved = sudoku.Solve();
							if (isSolved)
							{
								NumberFound(row, col, i);
								return Solve();
							}
						}
					}
				}
			}
			return false;
		}
		#endregion

		#endregion
	}
}
