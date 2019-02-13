using System;

namespace Useful.Challenges
{
    /// <summary>
    /// A class for solving the 3 Sailors and a Monkey problem.
    /// </summary>
	public class SailorsAndAMonkey
	{
		#region Variables
		private int[] m_sailorTotal;
		private int m_monkeyTotal;
		private int m_coconutsTotal;
		private int m_sailorCount;
		private int m_monkeyCount;
		#endregion

		#region Constructors
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
		public SailorsAndAMonkey()
		{
		}
		#endregion

		#region Properties
        /// <summary>
        /// Gets the total number of monkeys.
        /// </summary>
		public int MonkeyTotal
		{
			get
			{
				return m_monkeyTotal;
			}
		}

        /// <summary>
        /// Gets the total number of coconuts.
        /// </summary>
		public int CoconutsTotal
		{
			get
			{
				return m_coconutsTotal;
			}
		}

        /// <summary>
        /// Get the number of sailors.
        /// </summary>
		public int SailorCount
		{
			get
			{
				return m_sailorCount;
			}
		}

        /// <summary>
        /// Gets the number of monkeys.
        /// </summary>
		public int MonkeyCount
		{
			get
			{
				return m_monkeyCount;
			}
		}

		#endregion

		#region Methods
        /// <summary>
        /// Gets the total number of sailors.
        /// </summary>
        /// <returns></returns>
		public int[] GetSailorTotal()
		{
			return m_sailorTotal;
		}

        /// <summary>
        /// Starts the calculation.
        /// </summary>
        /// <param name="sailors">The number of sailors.</param>
        /// <param name="monkeys">The number of monkeys.</param>
		public void Calculate(int sailors, int monkeys)
		{
			int coconuts = 0;
			bool success = false;
			m_sailorCount = sailors;
			m_monkeyCount = monkeys;

			m_sailorTotal = new int[sailors];

			while (!success)
			{
				coconuts++;

				success = SplitCoconuts(coconuts);
			}

			m_coconutsTotal = coconuts;
			m_monkeyTotal = m_sailorCount + 1;
		}
		
		private bool SplitCoconuts(int Coconuts)
		{
			bool success = true;

			for (int i = 0 ; i < m_sailorCount ; i++)
			{
				// Can the coconuts be evenly divided between the sailors leaving some for the monkey?
				if ((Coconuts % m_sailorCount) == m_monkeyCount)
				{
					// Remove the coconuts for the monkey
					Coconuts -= m_monkeyCount;
					// Sailor removes his coconuts
					m_sailorTotal[i] = Coconuts / m_sailorCount;
					// Remove coconuts from the remiander
					Coconuts -= Coconuts / m_sailorCount;
				}
				else
				{
					success = false;
					break;
				}
			}

			// All sailors have removed their coconuts from the pile
			// Are there enough left for the final division?
			if (success && ((Coconuts % m_sailorCount) == m_monkeyCount))
			{
				// Remove the coconuts for the monkey
				Coconuts -= m_monkeyCount;

				// Split up Coconuts between the sailors
				for (int i = 0 ; i < m_sailorCount ; i++)
				{
					m_sailorTotal[i] += Coconuts / m_sailorCount;
				}
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion
	}
}
