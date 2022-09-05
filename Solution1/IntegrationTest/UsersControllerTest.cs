using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
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
            var response = await client.GetAsync("api/Users/all-users");

            Xunit.Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}