using System;

namespace Dota2ApiWrapper.Exceptions
{
    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException()
            : base()
        {
        }
        public ServiceUnavailableException(string message)
            : base(message)
        {
        }
        public ServiceUnavailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
