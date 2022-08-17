using Application;
using Application.Users.Commands.CreateUser;
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
        public RegisterUserMenu(AppState app) : base(app)
        {
            Message = "Registering new user";
            Options = new string[4] { "First Name: ", "Last Name: ", "User Name: ", "Password: " };
        }

        public override async void InteractWithUser()
        {
            BlankInputMenu menu = new BlankInputMenu(Message, Options);
            string[] inputs = menu.RunMenu();

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
