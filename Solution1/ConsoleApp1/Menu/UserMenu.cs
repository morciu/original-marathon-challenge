using Application;
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
        public void DisplayMenu()
        {
            Console.WriteLine("\nUser Menu\n");
           /* if (CurrentUser.currentUser.activity == null)
            {
                Console.WriteLine("1.Start Marathon\n2.Start Shared Marathon with another user\n0.Exit");
            }
            else
            {
                Console.WriteLine("1.Register run activity\n2.Check Marathon progress\n0.Exit");
            }*/
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

        public void ProcessInput(string input)
        {
        }

        public void SwitchMenu(string input, ref IMenu menu)
        {
           /* if (CurrentUser.currentUser.activity == null)
            {
                if (input == "1") { CurrentUser.currentUser.activity = new Marathon(); }
                else if (input == "2") { CurrentUser.currentUser.activity = new SharedPrivateMarathon(); }
            }
            else
            {
                if (input == "1") { menu = new RegisterRunActivity(); }

                else if (input == "2") { menu = new MarathonProgressMenu(); }
            }*/
        }
    }
}
