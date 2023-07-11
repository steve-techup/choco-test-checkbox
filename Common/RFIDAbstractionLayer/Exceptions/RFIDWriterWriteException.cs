using System;

namespace RFIDAbstractionLayer.Exceptions
{
    public class RFIDWriterWriteException : Exception
    {
        public RFIDWriterWriteException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
