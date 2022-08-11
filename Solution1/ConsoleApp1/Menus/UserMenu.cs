using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    internal class UserMenu : Menu
    {
        public UserMenu(AppState app) : base(app)
        {
            Message = $"Hello {App.CurrentUserName}!";
            Options = new string[3] { "Start Marathon", "Start Shared Marathon with another user", "Exit" };
        }

        public override void InteractWithUser()
        {
            Console.WriteLine(Message);
            Console.ReadLine();
        }
    }
}
