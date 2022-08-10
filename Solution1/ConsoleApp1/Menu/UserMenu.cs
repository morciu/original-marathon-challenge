using Application;
using Application.Users.Queries.GetUser;
using Domain;
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
    public class UserMenu : IMenu
    {
        private IMenu? nextMenu;
        private int _userId;
        public UserMenu(int userId)
        {
            _userId = userId;
        }
        public string DisplayMenu()
        {
            var diContainer = new ServiceCollection()
                .AddScoped<IUserRepository, InMemoryUserRepository>()
                .AddMediatR(typeof(IUserRepository))
                .BuildServiceProvider();

            // Get mediator
            var mediator = diContainer.GetRequiredService<IMediator>();

            var user = mediator.Send(new GetUserQueryCommand
            {
                Id = _userId
            });
            Console.WriteLine(user);

            Console.WriteLine("\nUser Menu\n");
            if (true)
            {
                Console.WriteLine("1.Start Marathon\n2.Start Shared Marathon with another user\n0.Exit");
            }
            else
            {
                Console.WriteLine("1.Register run activity\n2.Check Marathon progress\n0.Exit");
            }
            return "";
        }

        public string GetInput()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "0")
                {
                    return input;
                }
            }
        }

        public string GetState()
        {
            return "userMenu";
        }

        public string ProcessFlag()
        {
            throw new NotImplementedException();
        }

        public IMenu SwitchMenu()
        {
            return nextMenu;
        }
    }
}
