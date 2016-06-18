using System;

namespace DotaBuffWrapper.Exceptions
{
    internal class Dota2StatParserException : Exception
    {
        internal Dota2StatParserException(string message)
            : base(message)
        {

        }

        internal Dota2StatParserException(string message, Exception exception)
            : base(message, exception)
        {

        }
    }
}
