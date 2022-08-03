using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Menu
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
            string[] inputFields = input.Split(',');
            UserManager.currentUser = UserManager.CreateUser(inputFields[0], inputFields[1], inputFields[2], inputFields[3]);
            menu = new UserMenu();
        }

        public string GetState()
        {
            return "userRegistration";
        }
    }
}
