using Application.Activities.Queries.GetActivity;
using ConsolePresentation.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    public class CheckProgress : Menu
    {
        IMenuTemplateFactory menuTemplate;
        public CheckProgress(AppState app) : base(app)
        {
            // Get user activities
            var activities = App.mediator.Send(new GetAllUserActivitiesQuery { UserId = App.CurrentUserId });
            decimal totalDistance = activities.Result.Sum(d => d.Distance);
            TimeSpan totalTime = new TimeSpan(000000);
            foreach (var activity in activities.Result)
            {
                totalTime += activity.Duration;
            }

            Message = $"Marathon Progress:\nTotal Distance: {totalDistance}\nTotal Time: {totalTime}";
            Options = new string[2] {"Go Back", "Exit" };
        }

        public async override Task InteractWithUser()
        {
            menuTemplate = new SelectionMenuFactory();
            IMenuTemplate menu = menuTemplate.CreateMenuTemplate(Message, Options);
            menu.RunMenu();
            switch (menu.UserSelection)
            {
                case 0: App.currentMenu = new UserMenu(App); break;
                case 1: Environment.Exit(0); break;
            }
            await Task.Run(() => App.RunApp());
        }
    }
}
