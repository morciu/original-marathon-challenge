using ConsolePresentation.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    internal class CheckProgress : Menu
    {
        IMenuTemplateFactory menuTemplate;
        public CheckProgress(AppState app) : base(app)
        {
            Message = $"Marathon Progress:\nTotal Distance: <<PLACEHOLDER>>\nTotal Time: <<PLACEHOLDER>>";
            Options = new string[2] {"Go Back", "Exit" };
        }

        public override void InteractWithUser()
        {
            menuTemplate = new SelectionMenuFactory();
            IMenuTemplate menu = menuTemplate.CreateMenuTemplate(Message, Options);
            menu.RunMenu();
            switch (menu.UserSelection)
            {
                case 0: App.currentMenu = new UserMenu(App); break;
                case 1: Environment.Exit(0); break;
            }
        }
    }
}
