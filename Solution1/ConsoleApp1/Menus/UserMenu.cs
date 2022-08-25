using Application;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUser;
using Application.Activities.Queries.GetActivity;
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
    internal class UserMenu : Menu
    {
        IMenuTemplateFactory menuTemplate = new SelectionMenuFactory();
        public UserMenu(AppState app) : base(app)
        {
            Message = $"Hello {App.CurrentUserName}!";
            Options = new string[2] { "Start Marathon", "Exit" };
        }

        public async override Task InteractWithUser()
        {
            int input;
            var user = await App.mediator.Send(new GetUserByIdQueryCommand
            {
                Id = App.CurrentUserId,
            });

            // Update user activities in AppState.cs
            App.Activities = await App.mediator.Send(new GetAllUserActivitiesQuery
            {
                UserId = App.CurrentUserId,
            });

            Options = new string[] { "Register a run", "Check your progress", "Exit" };
            var menu = menuTemplate.CreateMenuTemplate(Message, Options);
            menu.RunMenu();
            input = menu.UserSelection;
            switch (input)
            {
                case 0: App.currentMenu = new RegisterRun(App); break;
                case 1: App.currentMenu = new CheckProgress(App); break;
                case 2: Environment.Exit(0); break;
            }
            await Task.Run(() => App.RunApp());
        }
    }
}
