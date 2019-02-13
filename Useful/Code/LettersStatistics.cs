using System;
using System.Globalization;
using System.Text;
// using Useful.Config;

namespace Useful
{
    /// <summary>
    /// A class to provide analysis on a group of letters.
    /// </summary>
	public static class Letters /* : IDisposable */
	{
//        int[] m_letterCount;
//        int[][] m_prevLetterCount;
//        int[][] m_nextLetterCount;
//        float[] m_letterFrequencies;
//        float[][] m_prevLetterFreqencies;
//        float[][] m_nextLetterFreqencies;
//        CultureInfo m_culture = new CultureInfo("en-GB");
        private static CultureInfo s_culture = new CultureInfo("en-GB");
//        ConfigWatcher m_config;
//        const int m_letterNum = 26;

//        /// <summary>
//        /// Initializes a new instance of this class. 
//        /// </summary>
//        public Letters()
//        {
//            Reset();
//        }

//        /// <summary>
//        /// Reset the object's letters.
//        /// </summary>
//        public void Reset()
//        {
//            ClearCounts();
//            ClearFrequencies();
//        }

//        /// <summary>
//        /// Clear out the current count values
//        /// </summary>
//        private void ClearCounts()
//        {
//            m_letterCount = new int[m_letterNum];
//            m_prevLetterCount = new int[m_letterNum][];
//            m_nextLetterCount = new int[m_letterNum][];
//            for (int i = 0; i < m_letterNum; i++)
//            {
//                m_prevLetterCount[i] = new int[m_letterNum];
//                m_nextLetterCount[i] = new int[m_letterNum];
//            }
//        }

//        /// <summary>
//        /// Clear out the current frequency values
//        /// </summary>
//        private void ClearFrequencies()
//        {
//            m_letterFrequencies = new float[m_letterNum];
//            m_prevLetterFreqencies = new float[m_letterNum][];
//            m_nextLetterFreqencies = new float[m_letterNum][];
//            for (int i = 0; i < m_letterNum; i++)
//            {
//                m_prevLetterFreqencies[i] = new float[m_letterNum];
//                m_nextLetterFreqencies[i] = new float[m_letterNum];
//            }
//        }

//        /// <summary>
//        /// Returns the letter frequencies for the letters.
//        /// </summary>
//        /// <returns>An array of frequencies representing a-z.</returns>
//        public float[] GetLetterFrequencies()
//        {
//            return m_letterFrequencies;
//        }

//        /// <summary>
//        /// Reads in letter frequencies from an config file.
//        /// </summary>
//        public void LoadLetterFrequencies()
//        {
//            //int letter;
//            m_letterFrequencies = new float[m_letterNum];

//            if (m_config == null)
//            {
//                m_config = new ConfigWatcher();
//                m_config.Changed += new EventHandler<ConfigChangedEventArgs>(m_config_Changed);
//            }

//            LoadLettersFromConfig();

//            //XmlDocument xDOM = new XmlDocument();
//            //xDOM.Load(@"statistics.xml");

//            //XmlNodeList nodelist = xDOM.SelectNodes("FREQUENCY/LETTERS/LETTER");

//            //XmlAttribute xAttr;
//            //foreach (XmlNode node in nodelist)
//            //{
//            //    xAttr = (XmlAttribute)node.Attributes.GetNamedItem("name");
//            //    letter = (int)xAttr.Value.ToCharArray()[0] % 'A';
//            //    xAttr = (XmlAttribute)node.Attributes.GetNamedItem("value");
//            //    m_letterFrequencies[letter] = float.Parse(xAttr.Value, m_culture);
//            //}
//            // TODO: Prev/Next letter frequencies

//            return;
//        }

//        void m_config_Changed(object sender, ConfigChangedEventArgs e)
//        {
//            LoadLettersFromConfig();
//        }

//        private void LoadLettersFromConfig()
//        {
//            foreach (UsefulConfigLetter letter in m_config.Config.Letters)
//            {
//                m_letterFrequencies[char.ToUpper(letter.Name[0], m_culture) % 'A'] = letter.Frequency;
//            }
//        }

//        /// <summary>
//        /// Reads in letters from some text.
//        /// </summary>
//        /// <param name="text">The text from which to read the letters from.</param>
//        public void ReadText(string text)
//        {
//            if (text == null)
//            {
//                throw new ArgumentNullException("text");
//            }

//            char letter;
//            char previousLetter;
//            char nextLetter;

//            //Clear out the current values
//            ClearFrequencies();

//            //Get First letter
////			cLetter = char.ToUpper(TextString[0]);

//            previousLetter = char.MinValue;
//            letter = char.ToUpper(text[0], m_culture);

//            //Get the rest of the text
//            for (int i = 1 ; i < text.Length ; i++)
//            {
//                nextLetter = char.ToUpper(text[i], m_culture);

//                //Add to stats
//                AddToLetterCount(letter, previousLetter, nextLetter);

//                //Shuffle letters for next read
//                previousLetter = letter;
//                letter = nextLetter;
//            }

//            //This will be for the last letter

//            AddToLetterCount(letter, previousLetter, char.MinValue);

//            //Calculate the frequency percentages
//            //Call objStrings.CopyArray(MyLetters.FrequencyPercent, objCrypt.CalcFrequencyPercentages(MyLetters.Frequency))
//            m_letterFrequencies = Statistics.CalcFrequencyPercentages(m_letterCount);
//            m_prevLetterFreqencies = Statistics.CalcFreqPercentages(m_prevLetterCount);
//            m_nextLetterFreqencies = Statistics.CalcFreqPercentages(m_nextLetterCount);
//        }

//        ///// <summary>
//        ///// 
//        ///// </summary>
//        ///// <param name="Letter"></param>
//        //private void AddToLetterCount(char Letter)
//        //{
//        //    AddToLetterCount(Letter, char.MinValue, char.MinValue);
//        //}

//        /// <summary>
//        /// Add a letter to the letter's frequency count.
//        /// </summary>
//        /// <param name="letter">The letter to add to.</param>
//        /// <param name="previousLetter">Letter that comes before this letter.</param>
//        /// <param name="nextLetter">Letter that comes after this letter.</param>
//        private void AddToLetterCount(char letter, char previousLetter, char nextLetter)
//        {
//            if (char.IsLetter(letter))
//            {
//                m_letterCount[char.ToUpper(letter, m_culture) % 'A']++;

//                if (char.IsLetter(previousLetter))
//                {
//                    //Add letter to previous letter spread
//                    m_prevLetterCount[char.ToUpper(letter, m_culture) % 'A'][char.ToUpper(previousLetter, new CultureInfo("en-GB")) % 'A']++;
//                }

//                if (char.IsLetter(nextLetter))
//                {
//                    //Add letter to next letter spread
//                    m_nextLetterCount[char.ToUpper(letter, m_culture) % 'A'][char.ToUpper(nextLetter, new CultureInfo("en-GB")) % 'A']++;
//                }
//            }
//        }

        /// <summary>
        /// Cleans a dirty string by making it uppercase and removing any non-letters.
        /// </summary>
        /// <param name="dirty">The dirty string to clean.</param>
        /// <param name="alphabet">The unicode alphabet to check the dirty letter is in.</param>
        /// <param name="options"></param>
        /// <returns>The clean string.</returns>
        public static char Clean(char dirty, Alphabets alphabet, CleanOptions options)
        {
            // Check to make sure the letter is in the specified alphabet
            if (Alphabet.GetAlphabetLetters(alphabet).Contains(dirty))
            {
                if ((options & CleanOptions.ToUpper) == CleanOptions.ToUpper)
                {
                    return char.ToUpper(dirty);
                }
                else 
                {
                    return dirty;
                }
            }
            else
            {
                return '\0';
            }
        }

        /// <summary>
        /// Cleans a dirty string by making it uppercase and removing any non-letters.
        /// </summary>
        /// <param name="dirty">The dirty string to clean.</param>
        /// <returns>The clean string.</returns>
		public static string CleanString(string dirty)
		{
			if (dirty == null)
			{
				throw new ArgumentNullException("dirty");
			}

            char.IsLetter('c');

			StringBuilder clean = new StringBuilder();

			for (int i = 0 ; i < dirty.Length ; i++)
			{
				if (char.IsLetter(dirty[i]))
				{
					clean.Append(dirty[i]);
				}
			}
			return clean.ToString().ToUpper(s_culture);
		}

        //#region IDisposable Members

        ///// <summary>
        ///// Releases all resources used by this object.
        ///// </summary>
        //public void Dispose()
        //{
        //    Dispose(true);
        //}

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected virtual void Dispose(bool disposing)
        //{
        //    // A call to Dispose(false) should only clean up native resources. 
        //    // A call to Dispose(true) should clean up both managed and native resources.
        //    if (disposing)
        //    {
        //        if (m_config != null)
        //        {
        //            m_config.Dispose();
        //        }
        //    }
        //}

        //#endregion
	}
}
