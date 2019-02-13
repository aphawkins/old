//-----------------------------------------------------------------------
// <copyright file="IUsefulCryptoTransformContract.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Additional Cryptography Transform Interface contract class.</summary>
//-----------------------------------------------------------------------

namespace Useful.Security.Cryptography
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Security.Cryptography;

    [ContractClassFor(typeof(ICryptoTransform))]
    internal abstract class ICryptoTransformContract : ICryptoTransform
    {
        bool ICryptoTransform.CanReuseTransform
        {
            get
            {
                return default(bool);
            }
        }

        bool ICryptoTransform.CanTransformMultipleBlocks
        {
            get
            {
                return default(bool);
            }
        }

        int ICryptoTransform.InputBlockSize
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return default(int);
            }
        }

        int ICryptoTransform.OutputBlockSize
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return default(int);
            }
        }

        int ICryptoTransform.TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            Contract.Requires(inputBuffer != null); // CA1062 suppressed
            Contract.Requires(inputOffset >= 0);
            Contract.Requires(inputCount >= 0);
            Contract.Requires(outputBuffer != null);
            Contract.Requires(outputOffset >= 0);
            Contract.Requires(inputOffset >= inputBuffer.GetLowerBound(0));
            Contract.Requires(inputOffset + inputCount <= inputBuffer.GetLowerBound(0) + inputBuffer.Length);

            Contract.Ensures(Contract.Result<int>() >= 0);

            return default(int);
        }

        byte[] ICryptoTransform.TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            Contract.Requires(inputBuffer != null);
            Contract.Requires(inputOffset >= 0);
            Contract.Requires(inputCount >= 0);
            Contract.Requires(inputOffset >= inputBuffer.GetLowerBound(0));
            Contract.Requires(inputOffset + inputCount <= inputBuffer.GetLowerBound(0) + inputBuffer.Length);

            Contract.Ensures(Contract.Result<byte[]>() != null);

            return default(byte[]);
        }

        void IDisposable.Dispose()
        {
            return;
        }
    }
}
