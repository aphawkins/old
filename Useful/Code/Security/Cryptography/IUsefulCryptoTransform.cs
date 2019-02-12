//-----------------------------------------------------------------------
// <copyright file="IUsefulCryptoTransform.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Additional Cryptography Transform Interface.</summary>
//-----------------------------------------------------------------------

namespace Useful.Security.Cryptography
{
    using System.Collections.Generic;

    /// <summary>
    /// Additional Cryptography Transform Interface.
    /// </summary>
    // [ContractClass(typeof(IUsefulCryptoTransformContract))]
#pragma warning disable Wintellect013 // Use a DebuggerDisplay attribute - Not allowed on Interfaces

    public interface IUsefulCryptoTransform // : ICryptoTransform
#pragma warning restore Wintellect013
    {
        /////// <summary>
        ///////
        /////// </summary>
        //////new bool CanReuseTransform
        //////{
        //////    get;
        //////}

        /////// <summary>
        ///////
        /////// </summary>
        ////new bool CanTransformMultipleBlocks
        ////{
        ////    get;
        ////}

        /////// <summary>
        ///////
        /////// </summary>
        //////new int InputBlockSize
        //////{
        //////    get;
        //////}

        /////// <summary>
        ///////
        /////// </summary>
        ////new int OutputBlockSize
        ////{
        ////    get;
        ////}

        /// <summary>
        /// Gets the cryptographic key value.
        /// </summary>
        /// <returns>The key value.</returns>
        ICollection<byte> Key
        {
            get;
        }

        /// <summary>
        /// Gets the cryptographic initialization vector value.
        /// </summary>
        /// <returns>The initialization vector value.</returns>
        ICollection<byte> IV
        {
            get;
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="inputBuffer"></param>
        ///// <param name="inputOffset"></param>
        ///// <param name="inputCount"></param>
        ///// <param name="outputBuffer"></param>
        ///// <param name="outputOffset"></param>
        ///// <returns></returns>
        ////new int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="inputBuffer"></param>
        ///// <param name="inputOffset"></param>
        ///// <param name="inputCount"></param>
        ///// <returns></returns>
        ////new byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount);

        /// <summary>
        /// Transforms an entire string.
        /// </summary>
        /// <param name="input">The input string to transform.</param>
        /// <returns>The transformed string.</returns>
        string TransformString(string input);
    }
}