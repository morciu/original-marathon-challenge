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
        public void DisplayMenu()
        {
            Console.WriteLine("Please fill in your user information.");
        }

        public string GetInput()
        {
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

        public void SwitchMenu(string input, ref IMenu menu)
        {
            menu = new UserMenu();
        }

        public string GetState()
        {
            return "userRegistration";
        }

        public void ProcessInput(string input)
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
            CurrentUser.currentUserName = inputFields[2];
        }
    }
}
