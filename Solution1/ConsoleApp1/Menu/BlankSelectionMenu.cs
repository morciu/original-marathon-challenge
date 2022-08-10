using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menu
{
    internal class BlankSelectionMenu
    {
        private int _currentSelection;
        private string[] _options;
        private string _message;

        public BlankSelectionMenu(string message, string[] options)
        {
            _options = options;
            _message = message;
        }

        private void DisplayOptions()
        {
            string symbol;
            Console.WriteLine(_message);
            for (int i = 0; i < _options.Length; i++)
            {
                if(_currentSelection == i) { 
                    symbol = "->";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else { 
                    symbol = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{symbol}{_options[i]}");
            }
            Console.ResetColor();
        }

        public int RunMenu()
        {
            ConsoleKey keyInput;

            do
            {
                // Clear previous console display and re-render menu
                Console.Clear();
                DisplayOptions();

                // Get key input
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyInput = keyInfo.Key;

                // Update _currentSelection according to arrow keys
                if(keyInput == ConsoleKey.DownArrow && _currentSelection < _options.Length-1) { _currentSelection++; }
                else if(keyInput == ConsoleKey.UpArrow && _currentSelection > 0) { _currentSelection--; }

            } while (keyInput != ConsoleKey.Enter);

            return _currentSelection;
        }
    }
}
