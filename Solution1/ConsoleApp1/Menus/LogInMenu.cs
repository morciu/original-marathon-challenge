using Application;
using Application.Users.Queries.GetUser;
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
        public LogInMenu(AppState app) : base(app)
        {
            Message = "Loggin In";
            Options = new string[2] { "User Name: ", "Password: " };
        }

        public async override void InteractWithUser()
        {
            BlankInputMenu menu = new BlankInputMenu(Message, Options);
            string[] inputs = menu.RunMenu();

            var diContainer = new ServiceCollection()
                .AddScoped<IUserRepository, InMemoryUserRepository>()
                .AddMediatR(typeof(IUserRepository))
                .BuildServiceProvider();

            // Get mediator
            var mediator = diContainer.GetRequiredService<IMediator>();

            // Get new user
            var loggedInUser = await mediator.Send(new GetUserQueryLoginCommand
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
                App.activityInfo = await mediator.Send(new GetUserActivityInfoQuery { Id = loggedInUser.Id });
            }

            
        }
    }
}
