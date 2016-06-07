using System;

namespace Dota2ApiWrapper.Exceptions
{
    public class MissingAccountIdException : Exception
    {
        public MissingAccountIdException()
            : base()
        {
        }

        public MissingAccountIdException(string message)
            : base(message)
        {
        }

        public MissingAccountIdException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
