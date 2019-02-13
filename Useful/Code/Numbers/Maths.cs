using System;

//namespace APH.Numbers
//{
//	public class Maths
//	{
//
//		public enum SearchMethod
//		{
//			Highest,
//			Lowest
//		}
//
//		public Maths()
//		{
////			Frequency = new int[26];
////			FrequencyPercent = new float[26];
////			PrevLetterSpreadFreq = new int[27, 27];
////			NextLetterSpreadFreq = new int[27, 27];
////			PrevSpreadFreqPercent = new float[27, 27];
////			NextSpreadFreqPercent = new float[27, 27];
//		}
//
////		public int[] Frequency;
////		public float[] FrequencyPercent;
////		public int[,] PrevLetterSpreadFreq;
////		public int[,] NextLetterSpreadFreq;
////		public float[,] PrevSpreadFreqPercent;
////		public float[,] NextSpreadFreqPercent;
//
//		/// <summary>
//		/// Calculate the frequency % for each letter
//		/// </summary>
//		/// <param name="FrequencyTable"></param>
//		/// <returns></returns>
//		public static float[] CalcFrequencyPercentages(int[] FrequencyTable)
//		{
//			int iTotalFreq = 0;
//			int i = 0;	//Counter
//
//			float[] fFrequencyPercent = new float[FrequencyTable.Length];
//
//			//sum the total frequency
//			for (i = 0 ; i < FrequencyTable.Length ; i++)
//			{
//				iTotalFreq += FrequencyTable[i];
//			}
//			
//			//calculate the % frequency
//			for (i = 0 ; i < FrequencyTable.Length ; i++)
//			{
//				if (FrequencyTable[i] == 0)
//				{
//					fFrequencyPercent[i] = 0;
//				}
//				else
//				{
//					fFrequencyPercent[i] = ((float)FrequencyTable[i] / (float)iTotalFreq) * 100f;
//				}
//			}
//			return fFrequencyPercent;
//		}
//
//		/// <summary>
//		/// Calculate the frequency percentages for 2D set of frequencies
//		/// </summary>
//		/// <param name="FrequencyTable"></param>
//		/// <returns></returns>
//		public static float[,] CalcFreqPercentages(int[,] FrequencyTable)
//		{		
//			int[] iArrayFreq = new int[26];
//			float[] fArrayFreqPercent;
//			float[,] fTotalArray = new float[26, 26];
//			
//			for (int i = 0 ; i <= FrequencyTable.GetUpperBound(0) ; i++)
//			{
//			    
//				//Do for each i frequency table
//				for (int j = 0 ; j <= FrequencyTable.GetUpperBound(1) ; j++)
//				{
//					iArrayFreq = new int[26];
//					iArrayFreq[j] = FrequencyTable[i, j];
//				}
//				
//				//Calculate the frequency percentages fo the i frequency table
//				fArrayFreqPercent = CalcFrequencyPercentages(iArrayFreq);
//				    
//				//Build a table as frequency percentages
//				for (int j = 0 ; j <= FrequencyTable.GetUpperBound(1) ; j++)
//				{
//					fTotalArray = new float[26, 26]; 
//					fTotalArray[i, j] = fArrayFreqPercent[j];
//				}
//			}
//			
//			return fTotalArray;
//		}
//  
//
//		/// <summary>
//		/// Calculate the frequency differences of numbers between two arrays
//		/// </summary>
//		/// <param name="FrequencyPercentages"></param>
//		/// <param name="FrequencyTable"></param>
//		/// <returns></returns>
//		public static float[] CalcFrequencyDifferences(float[] FrequencyPercentages, float[] FrequencyTable)
//		{
//			float[] fFreqDiff = new float[26];
//
//			//Calc the frequency difference
//			for (int i = 0 ; i < 26 ; i++)
//			{
//				fFreqDiff[i] = FrequencyTable[i] - FrequencyPercentages[i];
//			}
//
//			return fFreqDiff;
//		}
//
//		/// <summary>
//		/// Find the highest or lowest common denominator for a list of numerators
//		/// </summary>
//		/// <param name="Numerators"></param>
//		/// <param name="As"></param>
//		/// <returns></returns>
//		public static int FindCommonDenominator(int[] Numerators, SearchMethod SearchBy)
//		{
//			int iFrom;
//			int iTo;
//			int i = 0;
//
//			//Sort the array 
//			Array.Sort(Numerators);
//
//			//Lowest of highest common denominator?
//			if (SearchBy == SearchMethod.Lowest)
//			{
//				//Lowest - Count up
//				iFrom = 2;
//				iTo = Numerators[0];
//			}
//			else
//			{
//				//Highest - Count down
//				iFrom = Numerators[0];
//				iTo = 2;
//			}
//			
//			bool bFound = false;
//			i = iFrom;
//
//			while (!bFound)
//			{
//				//Go through all the numerators and see if the denominator divides into them all
//				for (int iNumCount = 0 ; (iNumCount < Numerators.Length) && !bFound ; iNumCount++)
//				{
//					if ((Numerators[iNumCount] % i) != 0)
//					{
//						bFound = false;
//						break;
//					}
//					if (iNumCount == Numerators.Length - 1)
//					{
//						bFound = true;
//					}
//				}
//				if (!bFound)
//				{
//					if (SearchBy == SearchMethod.Highest)
//					{
//						i--;
//						if (i < iTo)
//						{
//							break;
//						}
//					}
//					else
//					{
//						i++;
//						if (i > iTo)
//						{
//							break;
//						}
//					}
//				}
//			}
//			 
//			//Return the denominator or 0 if there isn't one
//			if (!bFound)
//			{
//				return 0;
//			}
//			else
//			{
//				return i;
//			}
//		}
//	}
//}
