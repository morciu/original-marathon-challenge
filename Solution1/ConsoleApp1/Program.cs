using Domain;
using Domain.Menu;
using Infrastructure;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Application;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUser;
using Application.Menus.Queries.GetMenu;
using MediatR;

// Building Container
var diContainer = new ServiceCollection()
    .AddScoped<IUserRepository, InMemoryUserRepository>()
    .AddScoped<IActivityRepository, InMemoryActivityRepository>()
    .AddScoped<IMenuRepository, InMemoryMenuRepository>()
    .AddMediatR(typeof(IUserRepository))
    .AddMediatR(typeof(IActivityRepository))
    .AddMediatR(typeof(IMenuRepository))
    .BuildServiceProvider();

// Get mediator
var mediator = diContainer.GetRequiredService<IMediator>();

// Create a new user through the mediator
var user = await mediator.Send(new CreateUserCommand
{
    Id = 5,
    FirstName = "SomeFirstName",
    LastName = "SomeLastName",
    UserName = "SomeUserName",
    Password = "SomePassWord"
});

Console.WriteLine(user.Id);
Console.WriteLine(user.FirstName);
Console.WriteLine(user.UserName);
Console.WriteLine(user.LastName);

var firstUser = await mediator.Send(new GetUserQueryCommand
{
    Id = 1
});

Console.WriteLine($"\nFirst User: {firstUser.UserName}\n");

// Set up menus
IMenu currentMenu = await mediator.Send(new GetMenuCommand
{
    Id = 1
});

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