using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    internal class InvalidInputLengthException : Exception
    {
        public InvalidInputLengthException(string input) : base(input)
        {
        }
    }
}
