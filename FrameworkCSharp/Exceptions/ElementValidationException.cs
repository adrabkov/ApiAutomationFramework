using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkCSharp.Exceptions
{
    class ElementValidationException : Exception
    {
        public ElementValidationException(string message)
            : base(message)
        {

        }
    }
}
