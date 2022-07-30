using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Menu
{
    public interface IMenu
    {
        public void DisplayMenu();
        public string GetInput();
        public string GetState();
        public void SwitchMenu(string input, ref IMenu menu);
    }
}
