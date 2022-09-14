using Application.Activities.Commands;
using Application.Users.Commands;
using Application.Users.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Moq;
using WebAPI.Controllers;
using WebAPI.ControllersHelpers;
using WebAPI.Dto;

namespace Test
{
    public class UsersControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();
        private readonly Mock<ILogger<UsersController>> _mockLogger = new Mock<ILogger<UsersController>>();
        private readonly Mock<LoggerHelper> _mockHelper = new Mock<LoggerHelper>();

        [Fact]
        public async Task Get_User_By_Id_GetUserByIdIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserByIdQueryCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act

            await controller.GetUsersById(5);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetUserByIdQueryCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_All_GetAllIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllUsers>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.GetAll();

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetAllUsers>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_User_Login_GetUserLoginIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUserQueryLoginCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.GetUserLogin("userName", "password");

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetUserQueryLoginCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Create_User_CreateUserIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);
            var testDto = new UserPutPostDto()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                UserName = "TestUserName",
                Password = "TestPassWord"
            };

            // Act
            await controller.CreateUser(testDto);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Add_Activity_To_User_AddActivityToUserIsCalled()
        {
            // Arrange
            _mockMediator
               .Setup(m => m.Send(It.IsAny<AddActivityToUser>(), It.IsAny<CancellationToken>()))
               .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.AddActivityToUser(5, 22);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<AddActivityToUser>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Delete_User_DeleteUserIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteUser>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new UsersController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.DeleteUser(5);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<DeleteUser>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
