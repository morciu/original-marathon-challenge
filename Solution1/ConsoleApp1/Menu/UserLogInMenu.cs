using Domain;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menu
{
    public class UserLogInMenu : IMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Please enter User Name and Password");
        }

        public string GetInput()
        {
            string? username;
            string? password;
            Console.Write("User Name: ");
            username = Console.ReadLine();
            InputValidator.ValidateInput(username);
            InputValidator.ValidateInputLength(username);

            Console.Write("Password: ");
            password = Console.ReadLine();

            return $"{username},{password}";
        }

        public string GetState()
        {
            return "userLogInMenu";
        }

        public void ProcessInput(string input)
        {
        }

        public void SwitchMenu(string input, ref IMenu menu)
        {
            string[] inputFields = input.Split(',');
          /*  if (CurrentUser.ValidateUser(inputFields[0], inputFields[1]))
            {
                menu = new UserMenu();
            }*/
        }
    }
}
