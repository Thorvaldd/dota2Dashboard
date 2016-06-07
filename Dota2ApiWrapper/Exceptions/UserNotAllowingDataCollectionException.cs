using System;

namespace Dota2ApiWrapper.Exceptions
{
    public class UserNotAllowingDataCollectionException : Exception
    {


        public UserNotAllowingDataCollectionException()
        {
        }
        public UserNotAllowingDataCollectionException(string message)
            : base(message)
        {
        }

        public UserNotAllowingDataCollectionException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
