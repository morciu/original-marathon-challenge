using Application;
using Application.Activities.Commands.CreateActivity;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ConsolePresentation.Menus
{
    internal class RegisterRun : Menu
    {
        public RegisterRun(AppState app) : base(app)
        {
            Message = "Enter your last run";
            Options = new string[2] { "Distance (km): ", "Time (h:m:s): " };
        }

        public override void InteractWithUser()
        {
            // Run Menu and get input
            BlankInputMenu menu = new BlankInputMenu(Message, Options);
            string[] inputs = menu.RunMenu();

            var mediator = SingletonMediator.Instance.GetMediator();

            // Store inputs for distance and duration
            decimal distance = Math.Round(decimal.Parse(inputs[0]));
            TimeSpan time = TimeSpan.Parse(inputs[1]);

            // Save activity
            mediator.Send(new CreateActivityCommand
            {
                RunnerId = App.CurrentUserId,
                Distance = distance,
                Duration = time,
                Date = DateTime.Now
            });

            App.currentMenu = new UserMenu(App);
        }
    }
}
