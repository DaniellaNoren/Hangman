using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class InvalidUserInputException : Exception
    {

        public InvalidUserInputException(string message) : base(message){}

        public InvalidUserInputException(string message, Exception inner) : base(message, inner) { }

        public InvalidUserInputException() { }
    }
}
