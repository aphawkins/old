using System;

namespace Useful
{
	/// <summary>
	/// A class containing static methods for statistical analysis. 
	/// </summary>
	public static class Statistics
	{
        private const int letterCount = 26;

		#region Standard Deviation
		/// <summary>
		/// Calculates Standard Deviation.
		/// </summary>
		/// <param name="values">x</param>
		/// <returns>Sqr(n(Sum(x^2)-(Sum x)^2) / (n(n-1)))</returns>
		public static float StandardDeviation(float[] values)
		{
			//// StdDev = Sqr(n(Sum(x^2)-(Sum x)^2) / (n(n-1)))

            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

			float sumX = (float)0;			//Sum x
			float sumXSquared = (float)0;	//Sum(x^2)

			int num = values.Length;		//n

			for (int i = 0 ; i < num ; i++)
			{
				sumX += values[i];	//Sum x
				sumXSquared += (float)Math.Pow(values[i], (double)2);	//Sum(x^2)
			}
	  
			//Calculate
			return (float)Math.Sqrt((((float)num * sumXSquared) - Math.Pow(sumX, (double)2)) / (num * (float)(num - 1)));
		}
		#endregion

		#region CalcFrequencyPercentages
		/// <summary>
		/// Calculates the frequency percentage for each letter in a frequency table.
		/// </summary>
		/// <param name="frequencyTable">The frequency of each letter.</param>
		/// <returns>The frequency of each letter as a percentage.</returns>
		public static float[] CalcFrequencyPercentages(int[] frequencyTable)
		{
            if (frequencyTable == null)
            {
                throw new ArgumentNullException("frequencyTable");
            }

			int totalFreq = 0;
			int i = 0;	//Counter

			float[] frequencyPercent = new float[frequencyTable.Length];

			//sum the total frequency
			for (i = 0 ; i < frequencyTable.Length ; i++)
			{
				totalFreq += frequencyTable[i];
			}
			
			//calculate the % frequency
			for (i = 0 ; i < frequencyTable.Length ; i++)
			{
				if (frequencyTable[i] == 0)
				{
					frequencyPercent[i] = 0;
				}
				else
				{
					frequencyPercent[i] = ((float)frequencyTable[i] / (float)totalFreq) * 100f;
				}
			}
			return frequencyPercent;
		}
		#endregion

		#region CalcFreqPercentages
		/// <summary>
		/// Calculates the frequency percentages for 2D set of letter frequencies.
		/// </summary>
        /// <param name="frequencyTable">The frequency of each letter.</param>
        /// <returns>The frequency of each letter as a percentage.</returns>
		public static float[][] CalcFreqPercentages(int[][] frequencyTable)
		{
            if (frequencyTable == null)
            {
                throw new ArgumentNullException("frequencyTable");
            }

			int[] arrayFreq = new int[letterCount];
			float[] arrayFreqPercent;
			float[][] totalArray = new float[letterCount][];
			
			for (int i = 0 ; i <= frequencyTable.Length ; i++)
			{
				//Do for each i frequency table
				for (int j = 0 ; j <= frequencyTable.GetUpperBound(1) ; j++)
				{
					arrayFreq = new int[letterCount];
					arrayFreq[j] = frequencyTable[i][j];
				}
				
				//Calculate the frequency percentages fo the i frequency table
				arrayFreqPercent = CalcFrequencyPercentages(arrayFreq);
				    
				//Build a table as frequency percentages
				for (int j = 0 ; j <= frequencyTable.GetUpperBound(1) ; j++)
				{
					totalArray[i][j] = arrayFreqPercent[j];
				}
			}
			
			return totalArray;
		}
		#endregion
  
		#region CalcFrequencyDifferences
		/// <summary>
		/// Calculate the frequency differences between two arrays of numbers.
		/// </summary>
		/// <param name="frequencyPercentages">The observed frequencies of letters.</param>
		/// <param name="frequencyTable">A pre-defined frequency of letters for the given alphabet.</param>
		/// <returns></returns>
		public static float[] CalcFrequencyDifferences(float[] frequencyPercentages, float[] frequencyTable)
		{
            // Validate args
            if (frequencyPercentages == null)
            {
                throw new ArgumentNullException("frequencyPercentages");
            }
            if (frequencyTable == null)
            {
                throw new ArgumentNullException("frequencyTable");
            }

			float[] freqDiff = new float[letterCount];

			//Calc the frequency difference
			for (int i = 0 ; i < letterCount ; i++)
			{
				freqDiff[i] = frequencyTable[i] - frequencyPercentages[i];
			}

			return freqDiff;
		}
		#endregion

		#region FindCommonDenominator
		/// <summary>
		/// Find the highest or lowest common denominator for a list of numerators.
		/// </summary>
		/// <param name="numerators">The list of numerators.</param>
        /// <param name="searchBy">The search method.</param>
		/// <returns></returns>
		public static int FindCommonDenominator(int[] numerators, SearchMethod searchBy)
		{
			int from;
			int to;
			int i = 0;
			bool found = false;

			//Sort the array 
			Array.Sort(numerators);

			//Lowest of highest common denominator?
			if (searchBy == SearchMethod.Lowest)
			{
				//Lowest - Count up
				from = 2;
				to = numerators[0];
			}
			else
			{
				//Highest - Count down
				from = numerators[0];
				to = 2;
			}
			
			i = from;

			while (!found)
			{
				//Go through all the numerators and see if the denominator divides into them all
				for (int numCount = 0 ; (numCount < numerators.Length) && !found ; numCount++)
				{
					if ((numerators[numCount] % i) != 0)
					{
						found = false;
						break;
					}
					if (numCount == numerators.Length - 1)
					{
						found = true;
					}
				}
				if (!found)
				{
					if (searchBy == SearchMethod.Highest)
					{
						i--;
						if (i < to)
						{
							break;
						}
					}
					else
					{
						i++;
						if (i > to)
						{
							break;
						}
					}
				}
			}
			 
			//Return the denominator or 0 if there isn't one
			if (!found)
			{
				return 0;
			}
			else
			{
				return i;
			}
		}
		#endregion
	}
}
