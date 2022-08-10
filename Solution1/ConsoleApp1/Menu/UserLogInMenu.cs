using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menu
{
    public class UserLogInMenu : IMenu
    {
        public string DisplayMenu()
        {
            Console.WriteLine("Please enter User Name and Password");
            string? username;
            string? password;

            Console.Write("User Name: ");
            username = Console.ReadLine();

            Console.Write("Password: ");
            password = Console.ReadLine();

            return $"{username},{password}";
        }

        public string GetState()
        {
            return "userLogInMenu";
        }

        public string ProcessFlag()
        {
            return "userMenu";
        }

        public IMenu SwitchMenu()
        {
            return null;
        }
    }
}
