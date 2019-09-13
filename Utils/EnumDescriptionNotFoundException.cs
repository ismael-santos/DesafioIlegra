using System;

namespace Utils
{
    public class EnumDescriptionNotFoundException : Exception
    {
        public EnumDescriptionNotFoundException(string message) : base (message) { }

        public EnumDescriptionNotFoundException() : base () { }
    }
}
