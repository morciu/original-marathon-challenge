using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class UserMenu : IMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("User Menu");
        }

        public string GetInput()
        {
            throw new NotImplementedException();
        }

        public string GetState()
        {
            return "userMenu";
        }

        public void SwitchMenu(string input, ref IMenu menu)
        {
            throw new NotImplementedException();
        }
    }
}
