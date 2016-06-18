using System;

namespace DotabuffWrapper.Exceptions
{
    internal class PlayerNotFoundException : Dota2StatParserException
    {
        internal PlayerNotFoundException(string message)
            : base(message)
        {

        }

        internal PlayerNotFoundException(string message, Exception exception)
            : base(message, exception)
        {

        }
    }
}
