using Application;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUser;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ConsolePresentation.Menus;

namespace ConsolePresentation
{
    public class AppState
    {
        // Current User
        public int CurrentUserId { get; set; }
        public string CurrentUserName { get; set; }

        // Current User activity info
        public Dictionary<string, string> activityInfo;

        // Current Menu
        public Menu currentMenu;

        public AppState()
        {
            currentMenu = new TitleMenu(this);
            activityInfo = new Dictionary<string, string>()
            {
                {"activity", "none" },
                {"totalDistance", "0" },
                {"activityIds", "" }
            };

        }

        public void RunApp()
        {
            currentMenu.InteractWithUser();
        }
/*
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
        }*/
    }
}
