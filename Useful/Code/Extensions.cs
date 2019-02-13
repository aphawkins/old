//-----------------------------------------------------------------------
// <copyright file="Extensions.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Extension methods.</summary>
//-----------------------------------------------------------------------

namespace Useful
{
    using System;

    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Checks for a null argument.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the expression.</typeparam>
        /// <param name="qwerty">The object to extend.</param>
        /// <param name="expression">The expression to test for null.</param>
        public static void CheckNullArgument<T>(this object qwerty, Func<T> expression) where T : class
        {
            if (qwerty == null)
            {
                throw new ArgumentNullException("qwerty");
            }

            Extensions.CheckNullArgument<T>(expression);
        }

        /// <summary>
        /// Checks for a null argument.
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the expression.</typeparam>
        /// <param name="expression">The expression to test for null.</param>
        public static void CheckNullArgument<T>(Func<T> expression) where T : class
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            if (expression() == null)
            {
                throw new ArgumentNullException("expression");
            }
        }

        /////// <summary>
        /////// 
        /////// </summary>
        /////// <param name="qwerty"></param>
        /////// <param name="argument"></param>
        ////public static void NotNull(this object qwerty, object argument) 
        ////{
        ////    if (argument == null) 
        ////    {
        ////        throw new ArgumentNullException("argument");
        ////    }
        ////}

        /////// <summary>
        /////// 
        /////// </summary>
        /////// <param name="qwerty"></param>
        /////// <param name="argument"></param>
        /////// <param name="minValue"></param>
        /////// <param name="maxValue"></param>
        ////public static void IndexOutOfRange(this object qwerty, int argument, int minValue, int maxValue)
        ////{
        ////    if (argument < minValue || argument > maxValue)
        ////    {
        ////        throw new ArgumentOutOfRangeException("argument");
        ////    }
        ////}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public static void IndexOutOfRange(int argument, int minValue, int maxValue)
        {
            if (argument < minValue || argument > maxValue)
            {
                throw new ArgumentOutOfRangeException("argument");
            }
        }
    }
}
