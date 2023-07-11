using System;

namespace RFIDAbstractionLayer.Exceptions
{
    public class RFIDReaderConnectionException : Exception
    {
        public RFIDReaderConnectionException(string message) : base(message)
        {

        }
    }
}
