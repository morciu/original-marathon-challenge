using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class InputValidator
    {
        public static void ValidateInput(string? input)
        {
            if (input == null || input.Length <= 0)
            {
                Console.WriteLine("Should throw exception.");
                throw new InvalidInputException("Field Empty!");
            }
        }
        public static void ValidateInputLength(string? input)
        {
            if (input == null || input.Length < 5)
            {
                throw new InvalidInputLengthException("Input must be at least 5 characters long");
            }
        }
    }
}
