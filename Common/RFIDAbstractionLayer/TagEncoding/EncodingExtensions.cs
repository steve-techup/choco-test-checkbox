using System;
using System.Linq;

namespace RFIDAbstractionLayer.TagEncoding
{
    public static class EncodingExtensions
    {
        /// <summary>
        /// Get bytes from number in the local endianness
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static byte[] getBytes(this uint number)
        {
            var numberBytes = BitConverter.GetBytes(number);
            if (BitConverter.IsLittleEndian)
                return numberBytes.Reverse().ToArray();
            return numberBytes;
        }

        /// <summary>
        /// Get bytes representing number in the desired endianness
        /// </summary>
        /// <param name="number"></param>
        /// <param name="littleEndian"></param>
        /// <returns></returns>
        public static byte[] getBytes(this ulong number, bool littleEndian = false)
        {
            var numberBytes = BitConverter.GetBytes(number);
            if (BitConverter.IsLittleEndian ^ littleEndian)
                return numberBytes.Reverse().ToArray();

            return numberBytes;
        }
    }
}
