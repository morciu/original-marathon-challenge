using Infrastructure;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Application;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUser;
using MediatR;
using ConsolePresentation.Menu;



// Building Container
var diContainer = new ServiceCollection()
    .AddScoped<IUserRepository, InMemoryUserRepository>()
    .AddScoped<IActivityRepository, InMemoryActivityRepository>()
    .AddMediatR(typeof(IUserRepository))
    .AddMediatR(typeof(IActivityRepository))
    .BuildServiceProvider();

// Get mediator
var mediator = diContainer.GetRequiredService<IMediator>();


/*// Create a new user through the mediator
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

// Get first user through mediator
var firstUser = await mediator.Send(new GetUserQueryCommand
{
    Id = 1
});

Console.WriteLine($"\nFirst User: {firstUser.UserName}\n");*/


// Set up main menu
IMenu currentMenu = new MainMenu();

// Current user Id
int currentUserId;

// Set up User Input
string userInput;

// Load registered users

// Testing Input
while (true)
{
    // Display current menu
    currentMenu.DisplayMenu();
    // Get user input
    userInput = currentMenu.GetInput();
    // Process user input
    currentMenu.ProcessInput(userInput);
    // Switch menu
    currentMenu.SwitchMenu(userInput, ref currentMenu);
    // Update/Change current menu

}