using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

using Useful.Challenges;

namespace Useful.Console
{
	static class Challenges
	{
		internal static void suDoku()
		{
			// Easy
			//int[][] grid = new int[9][]
			//{	
			//    new int[9] {0,2,0,8,1,0,7,4,0},
			//    new int[9] {7,0,0,0,0,3,1,0,0},
			//    new int[9] {0,9,0,0,0,2,8,0,5},
			//    new int[9] {0,0,9,0,4,0,0,8,7},
			//    new int[9] {4,0,0,2,0,8,0,0,3},
			//    new int[9] {1,6,0,0,3,0,2,0,0},
			//    new int[9] {3,0,2,7,0,0,0,6,0},
			//    new int[9] {0,0,5,6,0,0,0,0,8},
			//    new int[9] {0,7,6,0,5,1,0,9,0}
			//};

			// Medium
			//int[][] grid = new int[9][]
			//{	
			//    new int[9] {5,7,0,0,1,0,0,4,8},
			//    new int[9] {0,2,0,0,0,0,0,6,0},
			//    new int[9] {9,0,0,6,0,2,0,0,7},
			//    new int[9] {0,0,0,4,0,9,0,0,0},
			//    new int[9] {0,4,0,0,0,0,0,2,0},
			//    new int[9] {0,0,0,1,0,5,0,0,0},
			//    new int[9] {7,0,0,3,0,4,0,0,1},
			//    new int[9] {0,3,0,0,0,0,0,5,0},
			//    new int[9] {6,1,0,0,9,0,0,3,4}
			//};

			// Hard
			//int[][] grid = new int[9][]
			//{	
			//    new int[9] {5,0,0,0,0,2,6,0,0},
			//    new int[9] {0,7,8,0,0,6,0,2,0},
			//    new int[9] {0,2,0,0,0,0,9,0,3},
			//    new int[9] {0,0,0,6,0,0,8,0,0},
			//    new int[9] {4,0,0,0,0,0,0,0,1},
			//    new int[9] {0,0,7,0,0,4,0,0,0},
			//    new int[9] {3,0,2,0,0,0,0,5,0},
			//    new int[9] {0,9,0,5,0,0,1,7,0},
			//    new int[9] {0,0,1,8,0,0,0,0,6}
			//};

			// Very Hard
			//int[][] grid = new int[9][]
			//{	
			//    new int[9] {0,4,3,0,8,0,2,5,0},
			//    new int[9] {6,0,0,0,0,0,0,0,0},
			//    new int[9] {0,0,0,0,0,1,0,9,4},
			//    new int[9] {9,0,0,0,0,4,0,7,0},
			//    new int[9] {0,0,0,6,0,8,0,0,0},
			//    new int[9] {0,1,0,2,0,0,0,0,3},
			//    new int[9] {8,2,0,5,0,0,0,0,0},
			//    new int[9] {0,0,0,0,0,0,0,0,5},
			//    new int[9] {0,3,4,0,9,0,7,1,0}
			//};

			// Fiendish
			//int[][] grid = new int[9][]
			//{	
			//    new int[9] {0,0,0,0,1,0,0,0,7},
			//    new int[9] {0,0,8,7,0,0,3,0,0},
			//    new int[9] {0,0,0,0,0,5,0,9,1},
			//    new int[9] {0,0,0,0,3,0,2,6,0},
			//    new int[9] {0,4,0,0,0,0,0,5,0},
			//    new int[9] {0,6,9,0,8,0,0,0,0},
			//    new int[9] {5,9,0,4,0,0,0,0,0},
			//    new int[9] {0,0,2,0,0,8,6,0,0},
			//    new int[9] {3,0,0,0,2,0,0,0,0}
			//};

			int[][] grid = new int[9][]
			{	
			    new int[9] {0,0,0,0,0,0,0,0,0},
			    new int[9] {0,0,0,0,0,0,0,0,0},
			    new int[9] {0,0,0,0,0,0,0,0,0},
			    new int[9] {0,0,0,0,0,0,0,0,0},
			    new int[9] {0,0,0,0,0,0,0,0,0},
			    new int[9] {0,0,0,0,0,0,0,0,0},
			    new int[9] {0,0,0,0,0,0,0,0,0},
			    new int[9] {0,0,0,0,0,0,0,0,0},
			    new int[9] {0,0,0,0,0,0,0,0,0}
			};

			Debug.WriteLine("start: " + DateTime.Now.ToString());
			Sudoku suDoku = new Sudoku(grid);
			bool solved = suDoku.Solve();
			//int[][] solvedGrid = suDoku.GetGrid();
			Debug.WriteLine("end: " + DateTime.Now.ToString());
			Debug.WriteLine("solved: " + solved.ToString());
		}

		internal static void squares()
		{
			Squares.Run();
		}

		internal static void sailorsAndAMonkey(int Sailors, int Monkeys)
		{
			SailorsAndAMonkey sailorsAndAMonkey = new SailorsAndAMonkey();
			sailorsAndAMonkey.Calculate(Sailors, Monkeys);

			System.Console.WriteLine("\nNumber of Sailors = {0}", sailorsAndAMonkey.SailorCount);
			System.Console.WriteLine();
			System.Console.WriteLine("Sailor\tCoconunts");
			for (int i = 0; i < sailorsAndAMonkey.SailorCount; i++)
			{
				System.Console.WriteLine(" {0}\t{1}", i + 1, sailorsAndAMonkey.GetSailorTotal()[i]);
			}
			System.Console.WriteLine("Monkey\t{0}", sailorsAndAMonkey.MonkeyTotal);
			System.Console.WriteLine("===============");
			System.Console.WriteLine("Total\t{0}", sailorsAndAMonkey.CoconutsTotal);
		}

		internal static void queens(int GridSize)
		{
			Queens queens = new Queens();
			ReadOnlyCollection<int[]> results = queens.Process(GridSize);
			int[] result;

			if (results.Count == 0)
			{
				System.Console.WriteLine("No results");
				return;
			}
			for (int i = 0; i < results.Count; i++)
			{
				result = (int[])results[i];

				// Display
				System.Console.WriteLine(i + 1);

				// Go thru the rows
				for (int row = GridSize - 1; row > -1; row--)
				{
					// Go thru the columns
					for (int col = 0; col < GridSize; col++)
					{
						System.Console.Write("{0}", result[col] == row ? " Q" : " .");
					}
					System.Console.WriteLine();
				}
			}
		}
	}
}
