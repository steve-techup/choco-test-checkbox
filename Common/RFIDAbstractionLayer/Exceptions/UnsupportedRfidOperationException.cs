using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDAbstractionLayer.Exceptions
{
    /// <summary>
    /// Thrown when a specific reader implementation does not support the operation
    /// </summary>
    internal class UnsupportedRfidOperationException : Exception
    {
        public UnsupportedRfidOperationException(string reason) : base(reason)
        {

        }

        public UnsupportedRfidOperationException(string reason, Exception innerException) : base(reason,
            innerException)
        {

        }
    }
}
