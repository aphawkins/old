//-----------------------------------------------------------------------
// <copyright file="SubstitutionPair.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>A substituted pair of values for substitution based algorithms.</summary>
//-----------------------------------------------------------------------

namespace Useful.Security.Cryptography
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// A substituted pair of values for substitution based algorithms.
    /// </summary>
    public class SubstitutionPair
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the SubstitutionPair class.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public SubstitutionPair(char from, char to)
        {
            this.From = from;
            this.To = to;
        }
        #endregion

        #region Fields
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets where the plug is from.
        /// </summary>
        public char From { get; set; }

        /// <summary>
        /// Gets or sets where the plug goes to.
        /// </summary>
        public char To { get; set; }
        #endregion
        
        #region Methods
        internal static Collection<SubstitutionPair> GetPairs(Collection<char> allowedLetters, string key, char delimiter, bool checkUniqueness)
        {
            Contract.Requires(allowedLetters != null);
            Contract.Requires(key != null);
            Contract.Ensures(Contract.Result<Collection<SubstitutionPair>>() != null);

            Collection<SubstitutionPair> pairs = new Collection<SubstitutionPair>();
            string[] rawPairs = key.Split(new char[] { delimiter });

            Contract.Assert(rawPairs != null);
 
            // No plugs specified
            if (rawPairs.Length == 1 && rawPairs[0].Length == 0)
            {
                // Do nothing
            }
            else
            {
                // Check for plugs made up of pairs
                SubstitutionPair pair;

                foreach (string rawPair in rawPairs)
                {
                    if (rawPair == null)
                    {
                        continue;
                    }

                    if (rawPair.Length != 2)
                    {
                        throw new ArgumentException("Plug setting must be a pair.");
                    }

                    pair = new SubstitutionPair(rawPair[0], rawPair[1]);
                    Contract.Assert(pair != null);
                    pairs.Add(pair);
                }

                SubstitutionPair.CheckPairs(allowedLetters, pairs, checkUniqueness);
            }

            Contract.Assume(Contract.ForAll<SubstitutionPair>(pairs, x => x != null));

            return pairs;
        }

        [Pure]
        internal static bool CheckPairs(Collection<char> allowedLetters, Collection<SubstitutionPair> pairs, bool checkUniqueness)
        {
            Contract.Requires(allowedLetters != null);
            Contract.Requires(pairs != null);
            Contract.Ensures(Contract.OldValue(pairs) == pairs);

            if (pairs.Count > allowedLetters.Count)
            {
                throw new ArgumentException("Too many pair settings specified.");
            }

            List<char> uniqueLetters = new List<char>();

            foreach (SubstitutionPair pair in pairs)
            {
                if (!allowedLetters.Contains(pair.From))
                {
                    throw new ArgumentException("Not allowed to substitute these letters.");
                }

                if (!allowedLetters.Contains(pair.To))
                {
                    throw new ArgumentException("Not allowed to substitute these letters.");
                }

                if (checkUniqueness)
                {
                    // Can't do this here as it'll break the isSymmetric (Enigma) when re-setting to the same letter
                    // We need to do this here else you can set a substitution to the same letter!
                    if (pair.From == pair.To)
                    {
                        throw new ArgumentException("Letters cannot be duplicated in a substitution pair.");
                    }
                    
                    if (uniqueLetters.Contains(pair.From) || uniqueLetters.Contains(pair.To))
                    {
                        throw new ArgumentException("Pair letters must be unique.");
                    }

                    uniqueLetters.Add(pair.From);

                    ////if (uniqueLetters.Contains(to))
                    ////{
                    ////    throw new ArgumentException("Pair letters must be unique.");
                    ////}
                    uniqueLetters.Add(pair.To);
                }
            }

            return true;
        }
        #endregion
    }
}
