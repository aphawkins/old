using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Useful
{
    /// <summary>
    /// A static class containing mathematical procedures.
    /// </summary>
	public static class Maths
	{
		#region IntegerFactorization
		static byte[][] m_units = new byte[10][]
		{
			new byte[] {0,0,0,0,0,0,0,0,0,0},
			new byte[] {0,1,2,3,4,5,6,7,8,9},
			new byte[] {0,2,4,6,8,0,2,4,6,8},
			new byte[] {0,3,6,9,2,5,8,1,4,7},
			new byte[] {0,4,8,2,6,0,4,8,2,6},
			new byte[] {0,5,0,5,0,5,0,5,0,5},
			new byte[] {0,6,2,8,4,0,6,2,8,4},
			new byte[] {0,7,4,1,8,5,2,9,6,3},
			new byte[] {0,8,6,4,2,0,8,6,4,2},
			new byte[] {0,9,8,7,6,5,4,3,2,1}
		};

		static byte[][] m_tens = new byte[10][]
		{
			new byte[] {0,0,0,0,0,0,0,0,0,0},
			new byte[] {0,0,0,0,0,0,0,0,0,0},
			new byte[] {0,0,0,0,0,1,1,1,1,1},
			new byte[] {0,0,0,0,1,1,1,2,2,2},
			new byte[] {0,0,0,1,1,2,2,2,3,3},
			new byte[] {0,0,1,1,2,2,3,3,4,4},
			new byte[] {0,0,1,1,2,3,3,4,4,5},
			new byte[] {0,0,1,2,2,3,4,4,5,6},
			new byte[] {0,0,1,2,3,4,4,5,6,7},
			new byte[] {0,0,1,2,3,4,5,6,7,8}
		};

		static UIntHuge m_goal;
		static int m_depth;
		static List<byte[]> m_primes;

		static byte[] m_numsB;
		static byte[] m_numsA;

		private static CultureInfo m_culture = CultureInfo.InvariantCulture;


		/// <summary>
		/// 
		/// </summary>
		public static void IntegerFactorization()
		{
//			m_goal = new UIntHuge("143");			// 11 * 13
//			m_goal = new UIntHuge("10403");			// 101 * 103
//			m_goal = new UIntHuge("1022117");		// 1009 * 1013
//			m_goal = new UIntHuge("100160063");		// 10007 * 10009
			m_goal = new UIntHuge("9998000099");		// 99989 * 99991
//			m_goal = new UIntHuge(10002200057);		// 100003 * 100019
//			m_goal = new UIntHuge("305240780171");	// 552481 * 552491
//			m_goal = new UIntHuge(999962000357);	// 999979 * 999983

			m_depth = m_goal.Length;
			
			m_numsA = new byte[m_depth];
			m_numsB = new byte[m_depth];

            m_primes = new List<byte[]>();

			DateTime start = DateTime.Now;
			Debug.WriteLine("Start:= " + start.ToString("HH:mm:ss.fffffff", m_culture));
			 
			IntegerFactorizationRecursion(new UIntHuge("0"), 0);

			DateTime end = DateTime.Now;
			Debug.WriteLine("End:= " + end.ToString("HH:mm:ss.fffffff", m_culture));

			Debug.WriteLine("Diff:= " + ((TimeSpan)(end - start)).ToString());
			Debug.WriteLine("Total:= " + m_primes.Count);
		}

		private static void IntegerFactorizationRecursion(UIntHuge currentGoal, int depth)
		{
			for (byte a = 0 ; a < 10 ; a++)
			{
				m_numsA[depth] = a;

				for (byte b = 0 ; b < 10 ; b++)
				{
					m_numsB[depth] = b;

					UIntHuge g = currentGoal + CreateUIntHuge(m_numsA, m_numsB, depth);

					if (g > m_goal)
					{
						m_numsB[depth] = 0;
						break;
					}

					if (m_goal[depth] == g[depth])
					{
						if ((depth + 1) < m_depth)
						{
							IntegerFactorizationRecursion(g, depth + 1);
						}
						else
						{
							m_primes.Add(m_numsA);
						}
					}

				}
			}
			m_numsA[depth] = 0;
		}

		

	
	
		#endregion
	}
}
