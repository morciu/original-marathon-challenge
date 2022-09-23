using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Seed;

public static class UserCreator
{
    public static async Task SeedAsync(UserManager<User> userManager)
    {
        var applicationUser = new User
        {
            FirstName = "John",
            LastName = "Smith",
            UserName = "johnsmith",
            Email = "john@test.com",
            EmailConfirmed = true
        };

        var user = await userManager.FindByEmailAsync(applicationUser.Email);
        if (user == null)
        {
            var result = await userManager.CreateAsync(applicationUser, "Pass&01?");
        }
    }
}