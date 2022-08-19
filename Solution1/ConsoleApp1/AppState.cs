using Application;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUser;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ConsolePresentation.Menus;
using Domain;

namespace ConsolePresentation
{
    public class AppState
    {
        // Current User
        public int CurrentUserId { get; set; }
        public string CurrentUserName { get; set; }

        // Current User activity info
        public Dictionary<string, string> activityInfo;
        public List<Activity> Activities;

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
    }
}
