using ConsolePresentation.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    public class BlankInputMenu : IMenuTemplate
    {
        public string Message { get ; set ; }
        public string[] Options { get ; set; }
        public int UserSelection { get ; set ; }
        public string[] UserInput { get ; set; }

        public void RunMenu()
        {
            Console.Clear();
            string[] inputs = new string[Options.Length];
            for (int i = 0; i < Options.Length; i++)
            {
                Console.Write(Options[i]);
                inputs[i] = Console.ReadLine();
            }
            UserInput = inputs;
        }
    }
}
