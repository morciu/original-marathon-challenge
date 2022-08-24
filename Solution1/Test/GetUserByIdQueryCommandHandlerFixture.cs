using Application.Abstract;
using Application.Users.Queries.GetUser;
using Domain;
using Domain.Models;
using Moq;

namespace Test
{
    public class GetUserByIdQueryCommandHandlerFixture
    {
       /* private Mock<IUserRepository> _repoMock = new Mock<IUserRepository>();

        [Fact]
        public void HandleReturnsCorrectUser()
        {
            var command = new GetUserByIdQueryCommandHandler(_repoMock.Object);
            var request = new GetUserByIdQueryCommand()
            {
                Id = 1
            };
            _repoMock.Setup(m => m.GetUser(request.Id)).Returns(new User(request.Id, "Marian", "Pralea", "marian", "1234"));
            string expectedUserName = "marian";

            var result = command.Handle(request, new CancellationToken());

            Assert.Equal(expectedUserName, result.Result.UserName);
        }*/
    }
}