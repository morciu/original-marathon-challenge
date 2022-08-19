using Application;
using Application.Users.Commands.CreateUser;
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
    internal class RegisterUserMenu : Menu
    {
        IMenuTemplateFactory menuTemplate;
        public RegisterUserMenu(AppState app) : base(app)
        {
            Message = "Registering new user";
            Options = new string[4] { "First Name: ", "Last Name: ", "User Name: ", "Password: " };
        }

        public override async void InteractWithUser()
        {
            menuTemplate = new InputMenuFactory();
            var menu = menuTemplate.CreateMenuTemplate(Message, Options);
            menu.RunMenu();
            string[] inputs = menu.UserInput;

            var mediator = SingletonMediator.Instance.GetMediator();

            var newUser = await mediator.Send(new CreateUserCommand
            {
                FirstName = inputs[0],
                LastName = inputs[1],
                UserName = inputs[2],
                Password = inputs[3]
            });

            // Update current app user
            App.CurrentUserName = newUser.UserName;
            App.CurrentUserId = newUser.Id;

            // Set up next menu
            App.currentMenu = new UserMenu(App);
        }
    }
}
