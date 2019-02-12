//-----------------------------------------------------------------------
// <copyright file="IUsefulCryptoTransformContract.cs" company="APH Software">
//     Copyright (c) Andrew Hawkins. All rights reserved.
// </copyright>
// <summary>Additional Cryptography Transform Interface contract class.</summary>
//-----------------------------------------------------------------------

namespace Useful.Security.Cryptography
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Security.Cryptography;

    [ContractClassFor(typeof(IUsefulCryptoTransform))]
    internal abstract class IUsefulCryptoTransformContract : IUsefulCryptoTransform
    {
        //bool IUsefulCryptoTransform.CanReuseTransform
        //{
        //    get
        //    {
        //        return default(bool);
        //    }
        //}

        //bool IUsefulCryptoTransform.CanTransformMultipleBlocks
        //{
        //    get
        //    {
        //        return default(bool);
        //    }
        //}

        //int IUsefulCryptoTransform.InputBlockSize
        //{
        //    get
        //    {
        //        Contract.Ensures(Contract.Result<int>() >= 0);
        //        return default(int);
        //    }
        //}

        //int IUsefulCryptoTransform.OutputBlockSize
        //{
        //    get
        //    {
        //        Contract.Ensures(Contract.Result<int>() >= 0);
        //        return default(int);
        //    }
        //}

        //bool ICryptoTransform.CanReuseTransform
        //{
        //    get { throw new System.NotImplementedException(); }
        //}

        //bool ICryptoTransform.CanTransformMultipleBlocks
        //{
        //    get { throw new System.NotImplementedException(); }
        //}

        //int ICryptoTransform.InputBlockSize
        //{
        //    get { throw new System.NotImplementedException(); }
        //}

        //int ICryptoTransform.OutputBlockSize
        //{
        //    get { throw new System.NotImplementedException(); }
        //}

        ICollection<byte> IUsefulCryptoTransform.Key
        {
            get
            {
                Contract.Ensures(Contract.Result<ICollection<byte>>() != null);
                return default(byte[]);
            }
        }

        ICollection<byte> IUsefulCryptoTransform.IV
        {
            get
            {
                Contract.Ensures(Contract.Result<ICollection<byte>>() != null);
                return default(byte[]);
            }
        }

        //int IUsefulCryptoTransform.TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        //{
        //    Contract.Requires(inputBuffer != null); // CA1062 suppressed
        //    Contract.Requires(inputOffset >= 0);
        //    Contract.Requires(inputCount >= 0);
        //    Contract.Requires(outputBuffer != null);
        //    Contract.Requires(outputOffset >= 0);
        //    Contract.Requires(inputOffset >= inputBuffer.GetLowerBound(0));
        //    Contract.Requires(inputOffset + inputCount <= inputBuffer.GetLowerBound(0) + inputBuffer.Length);

        //    Contract.Ensures(Contract.Result<int>() >= 0);

        //    return default(int);
        //}

        //byte[] IUsefulCryptoTransform.TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        //{
        //    Contract.Requires(inputBuffer != null);
        //    Contract.Requires(inputOffset >= 0);
        //    Contract.Requires(inputCount >= 0);
        //    Contract.Requires(inputOffset >= inputBuffer.GetLowerBound(0));
        //    Contract.Requires(inputOffset + inputCount <= inputBuffer.GetLowerBound(0) + inputBuffer.Length);

        //    Contract.Ensures(Contract.Result<byte[]>() != null);

        //    return default(byte[]);
        //}

        string IUsefulCryptoTransform.TransformString(string input)
        {
            Contract.Requires(input != null);   // CA1062 Suppressed
            Contract.Requires(!input.Contains("\0"));
            Contract.Ensures(Contract.Result<string>() != null);

            return default(string);
        }

        //void System.IDisposable.Dispose()
        //{
        //    return;
        //}

        //int ICryptoTransform.TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        //{
        //    return default(int);
        //}

        //byte[] ICryptoTransform.TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
