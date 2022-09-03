using Application.Users.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Moq;
using WebAPI.Controllers;
using WebAPI.ControllersHelpers;

namespace Test
{
    public class UsersControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<UsersController>> _mockLogger = new Mock<ILogger<UsersController>>();
        private readonly Mock<ControllerHelper> _mockHelper = new Mock<ControllerHelper>();

        [Fact]
        public async Task Get_User_By_Id_GetUserByIdIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserByIdQueryCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.GetControllerName(It.IsAny<UsersController>())).Returns("TestControllerName");
            _mockHelper
                .Setup(h => h.GetActionName(It.IsAny<UsersController>())).Returns("TestActionName");

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act

            await controller.GetUsersById(5);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetUserByIdQueryCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
