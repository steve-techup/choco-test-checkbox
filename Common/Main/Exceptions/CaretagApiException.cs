using System;

namespace Main.Exceptions
{
    public class CaretagApiException : ApplicationException
    {
        public CaretagApiException(string message) : base(message)
        {

        }
    }
}
