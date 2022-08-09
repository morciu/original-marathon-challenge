using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menu
{
    public interface IMenu
    {
        public void DisplayMenu();
        public string GetInput();
        public string GetState();
        public void SwitchMenu(string input, ref IMenu menu);
        public void ProcessInput(string input);
    }
}
