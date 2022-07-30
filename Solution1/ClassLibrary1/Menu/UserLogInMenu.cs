using ClassLibrary1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Menu
{
    internal class UserLogInMenu : IMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Please enter User Name and Password");
        }

        public string GetInput()
        {
            string? username;
            string? password;
            try
            {
                Console.Write("User Name: ");
                username = Console.ReadLine();
                InputValidator.ValidateInput(username);
                InputValidator.ValidateInputLength(username);
            }
            catch (InvalidInputException)
            {
                throw;
            }
            catch (InvalidInputLengthException ex)
            {
                throw new Exception("Input Length exception occured", ex);
            }
            finally
            {
                Console.WriteLine("validation ended");
            }

            Console.Write("Password: ");
            password = Console.ReadLine();

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
