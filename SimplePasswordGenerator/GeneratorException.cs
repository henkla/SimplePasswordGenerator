using System;

namespace SimplePasswordGenerator
{
    public class GeneratorException : ApplicationException
    {
        public GeneratorException(string message) : base(message)
        {
        }

        public GeneratorException(string message, Exception exception) : base(message, exception) 
        {
        }
    }
}
