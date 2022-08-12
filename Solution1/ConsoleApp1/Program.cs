using Infrastructure;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Application;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUser;
using MediatR;
using ConsolePresentation;
using ConsolePresentation.Menus;



AppState app = new AppState();

while (true)
{
    app.RunApp();
}

