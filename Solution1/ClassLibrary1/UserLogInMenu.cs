using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class UserLogInMenu : IMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Please enter User Name and Password");
        }

        public string GetInput()
        {
            Console.Write("User Name: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            return $"{username},{password}";
        }

        public string GetState()
        {
            return "userLogInMenu";
        }

        public void SwitchMenu(string input, ref IMenu menu)
        {
            string[] inputFields = input.Split(',');
            if (UserManager.ValidateUser(inputFields[0], inputFields[1]))
            {
                menu = new UserMenu();
            }
        }
    }
}
