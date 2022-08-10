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

namespace ConsolePresentation.Menu
{
    public class UserRegistrationMenu : IMenu
    {
        private const string title = "Please fill in your user information.";
        private IMenu nextMenu;
        public string DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("User registration\n");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("User Name: ");
            string userName = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            return $"{firstName},{lastName},{userName},{password}";
        }
        public IMenu SwitchMenu()
        {
            return null;
        }

        public void ProcessInput(string input, CurrentAppState app)
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
            app.CurrentUserId = newUser.Id;
        }

        public string ProcessFlag()
        {
            return "registerUser";
        }
    }
}
