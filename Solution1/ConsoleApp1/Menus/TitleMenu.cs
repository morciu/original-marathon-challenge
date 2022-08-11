using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    internal class TitleMenu : Menu
    {
        public TitleMenu(AppState app) : base(app)
        {
            Message = "Welcome!";
            Options = new string[3] { "Log In", "Register new user", "Exit" };
        }

        public override void InteractWithUser()
        {
            BlankSelectionMenu menu = new BlankSelectionMenu(Message, Options);
            int input = menu.RunMenu();
            switch (input)
            {
                case 0: App.currentMenu = new LogInMenu(App); break;
                case 1: App.currentMenu = new RegisterUserMenu(App); break;
                case 2: Environment.Exit(0); break;
            }
        }
    }
}
