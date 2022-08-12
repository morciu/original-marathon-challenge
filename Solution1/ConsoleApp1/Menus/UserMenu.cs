using Application;
using Application.Users.Commands.UpdateUser;
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
    internal class UserMenu : Menu
    {
        IMediator mediator;
        public UserMenu(AppState app) : base(app)
        {
            Message = $"Hello {App.CurrentUserName}!";
            Options = new string[2] { "Start Marathon", "Exit" };

            var diContainer = new ServiceCollection()
                .AddScoped<IUserRepository, InMemoryUserRepository>()
                .AddMediatR(typeof(IUserRepository))
                .BuildServiceProvider();
            mediator = diContainer.GetRequiredService<IMediator>();
        }

        public async override void InteractWithUser()
        {
            BlankSelectionMenu menu;
            int input;
            var user = await mediator.Send(new GetUserByIdQueryCommand
            {
                Id = App.CurrentUserId,
            });

            // Check if user is signed up for a marathon, if not display menu to sign up
            if (App.activityInfo["activity"] == "none")
            {
                menu = new BlankSelectionMenu("You haven't started your Marathon yet.", Options);
                input = menu.RunMenu();
                switch (input)
                {
                    case 0: 
                        App.currentMenu = new UserMenu(App);
                        user.StartMarathon();
                        var updatedUser = await mediator.Send(new UpdateUserActivityCommand
                        {
                            Id = App.CurrentUserId,
                            Field = "activity",
                            Value = "marathon",
                        });
                        App.activityInfo = await mediator.Send(new GetUserActivityInfoQuery { Id = 1 });
                        break;
                    case 1: Environment.Exit(0); break;
                }
            }
            // If signed up display regular user menu
            else
            {
                user.StartMarathon();
                Options = new string[] { "Register a run", "Check your progress", "Exit" };
                menu = new BlankSelectionMenu("Keep running!", Options);
                input = menu.RunMenu();
                switch (input)
                {
                    case 0: App.currentMenu = new RegisterRun(App); break;
                    case 1: App.currentMenu = new CheckProgress(App); break;
                    case 2: Environment.Exit(0); break;
                }
            }
        }
    }
}
