using Domain;
using Domain.Menu;
using Infrastructure;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Application;
using Application.Users.Commands.CreateUser;
using MediatR;

// Building Container
var diContainer = new ServiceCollection()
    .AddScoped<IUserRepository, InMemoryUserRepository>()
    .AddScoped<IActivityRepository, InMemoryActivityRepository>()
    .AddMediatR(typeof(IUserRepository))
    .BuildServiceProvider();

// Get mediator
var mediator = diContainer.GetRequiredService<IMediator>();

// Create a new user through the mediator
var userId = await mediator.Send(new CreateUserCommand
{
    Id = 5,
    FirstName = "SomeFirstName",
    LastName = "SomeLastName",
    UserName = "SomeUserName",
    Password = "SomePassWord"
});

Console.WriteLine(userId);

// Set up menus
IMenu currentMenu = new MainMenu();

// Set up User Input
string userInput;



// Load registered users
UserManager.LoadRegisteredUsers();

// Testing Input
while (true)
{
    currentMenu.DisplayMenu();
    try
    {
        userInput = currentMenu.GetInput();
    }
    catch(Exception ex)
    {
        Console.WriteLine("Invalid Input");
        continue;
    }
#if DEBUG
    finally
    {
        Debug.WriteLine("Finalized Input Evaluation");
    }
#endif
    currentMenu.SwitchMenu(userInput, ref currentMenu);
    Console.WriteLine(currentMenu.GetState());
}