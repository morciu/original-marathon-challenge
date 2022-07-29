using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class UserRegistrationMenu : IMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Please fill in your user information.");
        }

        public string GetInput()
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("User Name: ");
            string userName = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            return $"{firstName},{lastName},{userName},{password}";
        }

        public void SwitchMenu(string input, ref IMenu menu)
        {
            throw new NotImplementedException();
        }

        public string GetState()
        {
            return "userRegistration";
        }
    }
}
