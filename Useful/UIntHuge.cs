using System;
using System.Text;
using System.Diagnostics;
using System.Globalization;

namespace Useful
{
	/// <summary>
	/// An unsigned huge interger type.
	/// </summary>
	public struct UIntHuge
	{
		byte[] number;
		private static CultureInfo s_culture = CultureInfo.InvariantCulture;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="number">Little endian.</param>
		public UIntHuge(byte[] number)
		{
			this.number = number;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="number">Big endian.</param>
		public UIntHuge(string number)
		{
			this.number = UIntHuge.Parse(number).GetValue();
		}

		/// <summary>
		/// Indexer declaration.
		/// </summary>
		public byte this [int index]
		{
			get 
			{
				// Check the index limits.
				if (index < 0 || index >= this.number.Length)
				{
					return 0;
				}
				else
				{
					return this.number[index];
				}
			}
			set
			{
				// Check the index limits.
				if (index < 0 || index >= this.number.Length)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				else
				{
					this.number[index] = value;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="number">Big endian.</param>
		/// <returns></returns>
		public static UIntHuge Parse(string number)
		{
			if (number == null)
			{
				throw new ArgumentNullException("number");
			}

			byte[] num = new byte[number.Length];

			number = Reverse(number);

			for (int i = 0 ; i < number.Length ; i++)
			{
				num[i] = byte.Parse(number.Substring(i, 1), s_culture);
			}

			return new UIntHuge(num);
		}

		/// <summary>
		/// Gets the numeric value of this type.
		/// </summary>
		/// <returns></returns>
		public byte[] GetValue()
		{
			return this.number;
		}

		/// <summary>
		/// Gets the number of digits in this number.
		/// </summary>
		public int Length
		{
			get
			{
				return this.number.Length;
			}
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

        /// <summary>
        /// Returns a value indicating whether this object's value is equal to another.
        /// </summary>
        /// <param name="operandX">This object.</param>
        /// <param name="operandY">The object to compare.</param>
        /// <returns></returns>
		public static bool operator == (UIntHuge operandX, UIntHuge operandY)
		{
			if (operandX.Length != operandY.Length)
			{
				return false;
			}
			for (int i = 0 ; i < operandX.Length ; i++)
			{
				if (operandX[i] != operandY[i])
				{
					return false;
				}
			}
			return true;
		}

        /// <summary>
        /// Returns a value indicating whether this object's value is not equal to another.
        /// </summary>
        /// <param name="operandX">This object.</param>
        /// <param name="operandY">The object to compare.</param>
        /// <returns></returns>
		public static bool operator != (UIntHuge operandX, UIntHuge operandY)
		{
			return !(operandX == operandY);
		}

		/// <summary>
        /// Greater than relational operator that returns true if the first operand is greater than the second, false otherwise.
		/// </summary>
        /// <param name="operandX">The first operand.</param>
        /// <param name="operandY">The second operand.</param>
        /// <returns>True if the first operand is greater than the second, false otherwise.</returns>
        public static bool operator >(UIntHuge operandX, UIntHuge operandY)
		{
			int biggestLength = 0;

            if (operandX.Length > operandY.Length)
			{
                biggestLength = operandX.Length;
			}
			else
			{
				biggestLength = operandY.Length;
			}

			for (int i = biggestLength ; i >= 0 ; i--)
			{
                if (operandX[i] > operandY[i])
				{
					return true;
				}
                else if (operandX[i] == operandY[i])
				{
					// try the next number
				}
				else
				{
					return false;
				}
			}
			// Numbers are equal
			return false;
		}

		/// <summary>
        /// Less than relational operator that returns true if the first operand is less than the second, false otherwise.
		/// </summary>
        /// <param name="operandX">The first operand.</param>
        /// <param name="operandY">The second operand.</param>
        /// <returns>True if the first operand is less than the second, false otherwise.</returns>
        public static bool operator < (UIntHuge operandX, UIntHuge operandY)
		{
			int biggestLength = 0;

            if (operandX.Length > operandY.Length)
			{
                biggestLength = operandX.Length;
			}
			else
			{
                biggestLength = operandY.Length;
			}

			for (int i = biggestLength ; i >= 0 ; i--)
			{
                if (operandX[i] < operandY[i])
				{
					return true;
				}
                else if (operandX[i] == operandY[i])
				{
					// try the next number
				}
				else
				{
					return false;
				}
			}
			// Numbers are equal
			return false;
		}

        /// <summary>
        /// Compares two types.
        /// </summary>
        /// <param name="operandX">The first operand.</param>
        /// <param name="operandY">The second operand.</param>
        /// <returns></returns>
        public static string Compare(UIntHuge operandX, UIntHuge operandY)
		{
            if (operandX == operandY)
			{
				return "x equals y";
			}
            else if (operandX < operandY)
			{
				return "x less than y";
			}
			else
			{
				return "x greater than y";
			}
		}

        /// <summary>
        /// Returns the sum of two values.
        /// </summary>
        /// <param name="operandX">The first operand.</param>
        /// <param name="operandY">The second operand.</param>
        /// <returns>The total of the two values.</returns>
        public static UIntHuge operator +(UIntHuge operandX, UIntHuge operandY)
		{
			int length = 0;
			byte carry = 0;

            if (operandX.Length > operandY.Length)
			{
                length = operandX.Length;
			}
			else
			{
				length = operandY.Length;
			}

			UIntHuge newNum = new UIntHuge(new byte[length]);

			for (int i = 0 ; i < length ; i++)
			{
                byte num = (byte)(operandX[i] + operandY[i] + carry);

				if (num < 10)
				{	
					newNum[i] = num;
					carry = 0;
				}
				else
				{
					newNum[i] = (byte)(num % 10);
					carry = 1;
				}
			}
			if (carry == 1)
			{
				UIntHuge newNum1 = new UIntHuge(new byte[length + 1]);
				for (int i = 0 ; i < length ; i++)
				{
					newNum1[i] = newNum[i];
				}
				newNum1[length] = carry;
				return newNum1;
			}
			else
			{
				return newNum;
			}
		}

        /// <summary>
        /// Returns the sum of two values.
        /// </summary>
        /// <param name="operandX">The first operand.</param>
        /// <param name="operandY">The second operand.</param>
        /// <returns>The total of the two values.</returns>
        public static UIntHuge Add(UIntHuge operandX, UIntHuge operandY)
		{
            return operandX + operandY;
		}


//		private static long AddNumber(long number, int depth)
//		{
//			return (number * (long)Math.Pow(10.0d, (double)depth) );
//		}
//
//		public static Goal AddNumber(Goal number, int[] numsA, int[] numsB, int depth)
//		{
//			long sum = 0;
//			long newNum = number.Number;
//
//			long a = (long)numsA[depth];
//			long b = (long)numsB[depth];
//
//			try
//			{
//
//				for (int i = 0 ; i < depth ; i++)
//				{
//					sum += (long)numsA[i] * b * (long)Math.Pow(10.0d, i);
//					sum += (long)numsB[i] * a * (long)Math.Pow(10.0d, i);
//				}
//			
//				newNum += AddNumber(sum, depth);
//				newNum += AddNumber((a * b * (long)Math.Pow(10.0d, depth)), depth);
//			}
//			catch
//			{
//				newNum = -1;
//			}
//
//			return new Goal(newNum);
//		}

		private static string Reverse(string str) 
		{ 
			/*termination condition*/
			if (1 == str.Length) 
			{ 
				return str; 
			} 
			else 
			{ 
				return Reverse(str.Substring(1)) + str.Substring(0, 1); 
			} 
		}

        private static UIntHuge CreateUIntHuge(byte[] numsA, byte[] numsB, int depth)
        {
            UIntHuge newNum = new UIntHuge(new byte[depth + 2]);

            byte a = numsA[depth];
            byte b = numsB[depth];

            for (int i = 0; i < depth; i++)
            {
                newNum += CreateUIntHuge(m_tens[numsA[i]][b], m_units[numsA[i]][b], i + depth);
                newNum += CreateUIntHuge(m_tens[numsB[i]][a], m_units[numsB[i]][a], i + depth);
            }

            newNum += CreateUIntHuge(m_tens[a][b], m_units[a][b], depth + depth);

            return newNum;
        }


        private static UIntHuge CreateUIntHuge(byte tens, byte units, int depth)
        {
            byte[] num = new byte[depth + 2];	// Depth + tens + units

            // Blank array
            for (int i = 0; i < depth; i++)
            {
                num[i] = 0;
            }
            num[depth] = units;
            num[depth + 1] = tens;

            return new UIntHuge(num);
        }

	}
}
