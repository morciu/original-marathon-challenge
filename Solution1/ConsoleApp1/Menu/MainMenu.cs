using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menu
{
    public class MainMenu : IMenu
    {
        private const string title = "Run The Original Marathon!";
        private const string introMsg = "\nDuring the Battle of Marathon, according to Herodotus, an Athenian runner named Pheidippides was sent to run from Athens to Sparta to ask for assistance before the battle. \nHe ran a distance of over 225 kilometers (140 miles), arriving in Sparta the day after he left.\nRecreate this distance in real life, at your own pace and in as many runs as you can.";
        private const string mainMenuOptions = "\nOptions:\n1. Create New User\n2. Log in with existing User\n0. Exit\n";
        private IMenu nextMenu;

        public string DisplayMenu()
        {
            string[] options = { "Register New User", "Log In Existing User", "Exit" };
            BlankSelectionMenu menu = new BlankSelectionMenu(title, options);
            int selection = menu.RunMenu();
            switch (selection)
            {
                case 0:
                    nextMenu = new UserRegistrationMenu();
                    break;
                case 1:
                    nextMenu = new UserLogInMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
            return "";
        }


        public string ProcessFlag()
        {
            return "";
        }

        public IMenu SwitchMenu()
        {
            return nextMenu;
        }
    }
}
