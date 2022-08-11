using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    public class BlankInputMenu
    {
        private string _message;
        private string[] _fields;
        public BlankInputMenu(string message, string[] fields)
        {
            _message = message;
            _fields = fields;
        }

        public string[] RunMenu()
        {
            Console.Clear();
            string[] inputs = new string[_fields.Length];
            for (int i = 0; i < _fields.Length; i++)
            {
                Console.Write(_fields[i]);
                inputs[i] = Console.ReadLine();
            }
            return inputs;
        }
    }
}
