using Application.Users.Commands;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WebAPI.Dto;
using Xunit;

namespace IntegrationTest
{
    public class UsersControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private static WebApplicationFactory<Program> _factory;

        public UsersControllerTest()
        {
            _factory = new CustomWebApplicationFactory<Program>();
        }

        [Fact]
        public async void Get_All_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/users/all-users");

            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void Get_All_ShouldReturnValidUser()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/users/all-users");

            var result = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserGetDto>>(result);

            var firstUser = users.FirstOrDefault(u => u.Id == 1);
            UserAsserts(firstUser);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnValidUser()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/users/1");

            var result = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserGetDto>(result);

            UserAsserts(user);
        }

        // Create asserts for testing first user
        private static void UserAsserts(UserGetDto user)
        {
            Xunit.Assert.Equal("buffy", user.UserName);
            Xunit.Assert.Equal(1, user.Id);
        }
    }
}