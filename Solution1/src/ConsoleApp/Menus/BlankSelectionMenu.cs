using ConsolePresentation.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    internal class BlankSelectionMenu : IMenuTemplate
    {
        private int _currentSelection;
        public string Message { get ; set ; }
        public string[] Options { get ; set ; }
        public int UserSelection { get; set; }
        public string[] UserInput { get ; set ; }

        private void DisplayOptions()
        {
            string symbol;
            Console.WriteLine(Message);
            for (int i = 0; i < Options.Length; i++)
            {
                if (_currentSelection == i)
                {
                    symbol = "->";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    symbol = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{symbol}{Options[i]}");
            }
            Console.ResetColor();
        }

        public void RunMenu()
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
                if (keyInput == ConsoleKey.DownArrow && _currentSelection < Options.Length - 1) { _currentSelection++; }
                else if (keyInput == ConsoleKey.UpArrow && _currentSelection > 0) { _currentSelection--; }

            } while (keyInput != ConsoleKey.Enter);

            UserSelection = _currentSelection;
        }
    }
}
