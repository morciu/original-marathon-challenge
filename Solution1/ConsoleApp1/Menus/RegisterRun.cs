using Application;
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
            BlankInputMenu menu = new BlankInputMenu(Message, Options);
            string[] inputs = menu.RunMenu();

            var diContainer = new ServiceCollection()
                .AddScoped<IUserRepository, InMemoryUserRepository>()
                .AddMediatR(typeof(IUserRepository))
                .BuildServiceProvider();
            var mediator = diContainer.GetRequiredService<IMediator>();


        }
    }
}
