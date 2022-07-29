using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MainMenu : IMenu
    {
        public const string title = "Run The Original Marathon!";
        public const string introMsg = "\nDuring the Battle of Marathon, according to Herodotus, an Athenian runner named Pheidippides was sent to run from Athens to Sparta to ask for assistance before the battle. \nHe ran a distance of over 225 kilometers (140 miles), arriving in Sparta the day after he left.\nRecreate this distance in real life, at your own pace and in as many runs as you can.";
        public const string mainMenuOptions = "\nOptions:\n1. Create New User\n2. Log in with existing User\n0. Exit\n";

        public void DisplayMenu()
        {
            Console.WriteLine(title);
            Console.WriteLine(introMsg);
            Console.WriteLine(mainMenuOptions);
        }

        public string GetInput()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "0")
                {
                    return input;
                }
            }
        }

        public string GetState()
        {
            return "mainMenu";
        }

        public void SwitchMenu(string input, ref IMenu menu)
        {
            if (input == "1") { menu = new UserRegistrationMenu(); }
            else if (input == "2") { menu = new UserLogInMenu(); }
            else if (input == "0") { Environment.Exit(0); }
        }
    }
}
