using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RFIDAbstractionLayer.TagEncoding
{
    /// <summary>
    /// A bit array for storing bits in a BE way. 
    /// </summary>
    public class BEBitArray
    {
        private readonly BitArray _ba;

        public BEBitArray(int length)
        {
            _ba = new BitArray(length);
        }
        
        /// <summary>
        /// Create BEBitArray from LE? byte array. 
        /// </summary>
        /// <param name="bytes"></param>
        public BEBitArray(byte[] bytes)
        {
            _ba = new BitArray(bytes.Length * 8);
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _ba[i * 8 + j] = (bytes[i] & (1 << (7 - j))) != 0;
                }
            }
        }

        /// <summary>
        /// Write bytes at position in bits,
        /// </summary>
        /// <param name="position"></param>
        /// <param name="bytes"></param>
        public void Write(int position, byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _ba[position + i * 8 + j] = (bytes[i] & (1 << (7 - j))) != 0;
                }
            }
        }

        /// <summary>
        /// Write bytes at targetPosition in bits, from sourceOffset with length. 
        /// </summary>
        /// <param name="targetPosition"></param>
        /// <param name="sourceOffset"></param>
        /// <param name="length"></param>
        /// <param name="bytes"></param>
        public void Write(int targetPosition, int sourceOffset, int length, byte[] bytes)
        {
            for (int i = 0; i < length; i++)
            {
                var sourcePointer = i + sourceOffset;
                _ba[targetPosition + i] = (bytes[sourcePointer / 8] & (1 << (7 - sourcePointer % 8))) != 0;
            }
        }

        /// <summary>
        /// Write byte a position
        /// </summary>
        /// <param name="position">Position in bits</param>
        /// <param name="b"></param>
        public void Write(int position, byte b)
        {
            for (int j = 0; j < 8; j++)
            {
                _ba[position + j] = (b & (1 << (7 - j))) != 0;
            }
        }
        
        /// <summary>
        /// Returns an IEnumerable of the bytes representing this bit array, or a subset starting from offset to length. 
        /// </summary>
        /// <param name="offset">Offset in bits</param>
        /// <param name="length">Length in bits</param>
        /// <returns></returns>
        public IEnumerable<byte> ToBytes(int offset = 0, int length = -1)
        {
            int rightshift = length > 0 ? Math.Abs(length - (int) (Math.Ceiling(length / 8.0) * 8.0)) : 0;

            int bitCount = 7- rightshift;
            int outByte = 0;

            if (length == -1)
                length = _ba.Length;
            
            foreach (bool bitValue in _ba)
            {
                if (offset > 0)
                {
                    offset--; 
                    continue;
                }
                if (length-- == 0)
                    break;

                if (bitValue)
                    outByte |= 1 << bitCount;
                if (bitCount == 0)
                {
                    yield return (byte)outByte;
                    bitCount = 8;
                    outByte = 0;
                }
                bitCount--;
            }
            // Last partially decoded byte
            if (bitCount < 7)
                yield return (byte)outByte;
        }
    }
}
