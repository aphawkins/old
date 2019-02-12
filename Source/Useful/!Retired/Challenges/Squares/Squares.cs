using System;
using System.Collections.Generic;

namespace Useful.Challenges
{
    /// <summary>
    /// A class for solving the Squares problem.
    /// </summary>
	public static class Squares
	{
        /// <summary>
        /// Starts the processing.
        /// </summary>
		public static void Run()
		{
			int[] squareSize = new int[24];
			int[] sideLength = new int[4];
			List<int[]> results = new List<int[]>();

			for (int i_0 = 1 ; i_0 < 10000 ; i_0++)
			{
				squareSize[0] = i_0;

				for (int i_1 = i_0 + 1 ; i_1 < (i_0 * 3) ; i_1++)
				{
					squareSize[1] = i_1;

					for (int i_2 = i_1 + 1 ; i_2 < (i_1 * 3) ; i_2++)
					{
						squareSize[2] = i_2;
						squareSize[3] = squareSize[0] + squareSize[2];
						squareSize[4] = squareSize[0] + squareSize[3];

						for (int i_5 = squareSize[4] + 1 ; i_5 < (squareSize[4] * 3) ; i_5++)
						{
							squareSize[5] = i_5;
							squareSize[6] = squareSize[3] + squareSize[4];
							squareSize[7] = squareSize[4] + squareSize[6];
							squareSize[8] = squareSize[2] + squareSize[3] + squareSize[6];
							squareSize[10] = squareSize[0] + squareSize[4] + squareSize[7];
							squareSize[9] = (squareSize[0] + squareSize[10]) - squareSize[2];
							squareSize[16] = squareSize[9] + squareSize[10];
							squareSize[17] = squareSize[6] + squareSize[7] + squareSize[8];
							squareSize[20] = squareSize[8] + squareSize[17];
							squareSize[21] = squareSize[9] + squareSize[16];

							for (int i_11 = squareSize[10] + 1 ; i_11 < (squareSize[10] * 3) ; i_11++)
							{
								squareSize[11] = i_11;
								squareSize[13] = squareSize[1] + squareSize[11];
								squareSize[14] = squareSize[1] + squareSize[13];
								squareSize[22] = squareSize[13] + squareSize[14];
								squareSize[15] = squareSize[1] + squareSize[14];
								squareSize[18] = squareSize[5] + squareSize[15];
								squareSize[19] = squareSize[5] + squareSize[18];
								squareSize[12] = (squareSize[5] + squareSize[19]) - squareSize[11];
								squareSize[23] = squareSize[12] + squareSize[19];

								sideLength[0] = squareSize[20] + squareSize[17] + squareSize[23];
								sideLength[1] = squareSize[23] + squareSize[19] + squareSize[18];
								sideLength[2] = squareSize[22] + squareSize[14] + squareSize[15] + squareSize[18];
								sideLength[3] = squareSize[20] + squareSize[21] + squareSize[22];

								if (sideLength[0] == sideLength[1])
								{
									if (sideLength[2] == sideLength[3])
									{
										if (sideLength[0] == sideLength[2])
										{
											//Yahoo!
											int[] i = new int[24];
											squareSize.CopyTo(i, 0);
											results.Add(i);
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
