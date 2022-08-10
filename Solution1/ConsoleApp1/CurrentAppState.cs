using Application;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUser;
using ConsolePresentation.Menu;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation
{
    public class CurrentAppState
    {
        public IMenu currentMenu;

        // Current User
        public int CurrentUserId { get; set; }
        public string CurrentUserName { get; set; }

        // Latest user input
        string UserInput { get; set; }

        public CurrentAppState()
        {
            currentMenu = new MainMenu();
        }

        public void RunApp()
        {
            UserInput = currentMenu.DisplayMenu();
        }

        public void UpdateApp()
        {
            switch (currentMenu.ProcessFlag())
            {
                case "login":
                    LogInUser(UserInput);
                    break;
                case "registerUser":
                    CreateUser(UserInput);
                    break;
                default:
                    break;
            }
        }

        public void UpdateMenu()
        {
            if ((currentMenu is UserRegistrationMenu) || (currentMenu is UserLogInMenu))
                currentMenu = new UserMenu(CurrentUserId);
            else
                currentMenu = currentMenu.SwitchMenu();
        }

        private async void CreateUser(string input)
        {
            string[] inputFields = input.Split(',');
            // Building Container
            var diContainer = new ServiceCollection()
                .AddScoped<IUserRepository, InMemoryUserRepository>()
                .AddMediatR(typeof(IUserRepository))
                .BuildServiceProvider();

            // Get mediator
            var mediator = diContainer.GetRequiredService<IMediator>();

            var newUser = mediator.Send(new CreateUserCommand
            {
                FirstName = inputFields[0],
                LastName = inputFields[1],
                UserName = inputFields[2],
                Password = inputFields[3]
            });
            CurrentUserId = newUser.Id;
        }

        private async void LogInUser(string input)
        {
            string[] inputFields = input.Split(',');

            var diContainer = new ServiceCollection()
                .AddScoped<IUserRepository, InMemoryUserRepository>()
                .AddMediatR(typeof(IUserRepository))
                .BuildServiceProvider();

            // Get mediator
            var mediator = diContainer.GetRequiredService<IMediator>();

            var loggedInUser = await mediator.Send(new GetUserQueryLoginCommand
            {
                UserName = inputFields[0],
                Password = inputFields[1],
            });
            CurrentUserId = loggedInUser.Id;
            CurrentUserName = loggedInUser.UserName;
        }
    }
}
