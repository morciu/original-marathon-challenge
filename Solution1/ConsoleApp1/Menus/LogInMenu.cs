using Application;
using Application.Users.Queries.GetUser;
using ConsolePresentation.Factories;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    public class LogInMenu : Menu
    {
        IMenuTemplateFactory menuTemplate;
        public LogInMenu(AppState app) : base(app)
        {
            Message = "Loggin In";
            Options = new string[2] { "User Name: ", "Password: " };
        }

        public async override Task InteractWithUser()
        {
            menuTemplate = new InputMenuFactory();
            var menu = menuTemplate.CreateMenuTemplate(Message, Options);
            menu.RunMenu();
            string[] inputs = menu.UserInput;

            // Get new user
            var loggedInUser = await App.mediator.Send(new GetUserQueryLoginCommand
            {
                UserName = inputs[0],
                Password = inputs[1],
            });

            // Update currentUser in application
            if (loggedInUser != null)
            {
                App.CurrentUserName = loggedInUser.UserName;
                App.CurrentUserId = loggedInUser.Id;
                // Set up next menu
                App.currentMenu = new UserMenu(App);
            }
            else
            {
                Console.WriteLine("Invalid Login");
                Console.WriteLine("Press any key to try again");
                Console.ReadLine();
                App.currentMenu = new LogInMenu(App);
            }
            await Task.Run(() => App.RunApp());
        }
    }
}
