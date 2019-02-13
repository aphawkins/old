using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Useful
{
    /// <summary>
    /// Provides Unicode alphabet functionality
    /// </summary>
    public static class Alphabet
    {
        private static Collection<char> m_latinBasic = new Collection<char>();

        static Alphabet()
        {
            for (int i = 0; i < 26; i++)
            {
                m_latinBasic.Add((char)(i + 65));
                m_latinBasic.Add((char)(i + 97));
            }
        }

        /// <summary>
        /// Retrieves the specified alphabet.
        /// </summary>
        /// <param name="alphabets">The alphabet to retrieve.</param>
        /// <returns></returns>
        public static Collection<char> GetAlphabetLetters(Alphabets alphabets)
        {
            switch (alphabets)
            {
                case Alphabets.LatinBasic:
                    {
                        return m_latinBasic;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }
    }
}
