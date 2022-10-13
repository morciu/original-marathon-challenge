using Application.Activities.Commands;
using Application.Activities.Queries;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.Filter;
using WebApi.Services;
using WebAPI.Controllers;
using WebAPI.ControllersHelpers;
using WebAPI.Dto;

namespace Test.ControllerTests
{
    public class ActivityControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new();
        private readonly Mock<IMapper> _mockMapper = new();
        private readonly Mock<ILogger<ActivityController>> _mockLogger = new();
        private readonly Mock<LoggerHelper> _mockHelper = new();
        private readonly Mock<IUriService> _mockUriService = new();
        private readonly Mock<PaginationFilter> _mockPagFilt = new();

        [Fact]
        public async Task Get_All_GetAllIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllActivitiesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new ActivityController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object, _mockUriService.Object);

            // Act
            await controller.GetAll();

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetAllActivitiesQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_Activity_By_Id_GetActivityByIdIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetActivityByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new ActivityController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object, _mockUriService.Object);

            // Act
            await controller.GetActivityById(5);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetActivityByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Get_All_User_Activities_GetAllUserActivitiesIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllUserActivitiesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new ActivityController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object, _mockUriService.Object);

            // Act
            await controller.GetAllUserActivities(_mockPagFilt.Object, 5);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetAllUserActivitiesQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Create_Activity_CreateActivityIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateActivityCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new ActivityController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object, _mockUriService.Object);

            var dto = new ActivityPutPostDto()
            {
                UserId = 1,
                Distance = 5.56m,
                Date = DateTime.Now,
                Duration = new TimeSpan(0, 32, 23),
            };

            // Act
            await controller.CreateActivity(dto);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<CreateActivityCommand>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Delete_Activity_DeleteActivityIsCalle()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteActivity>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.LogControllerAndAction(It.IsAny<ActivityController>())).Returns("Mock logger message");

            var controller = new ActivityController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object, _mockUriService.Object);

            // Act
            await controller.DeleteActivity(5);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<DeleteActivity>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
