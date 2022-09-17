using Application.Marathons.Commands;
using Application.Marathons.Queries;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.ControllersHelpers;
using WebAPI.Dto;

namespace Test.ControllerTests
{
    public class MarathonControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new();
        private readonly Mock<IMapper> _mockMapper = new();
        private readonly Mock<ILogger<MarathonController>> _mockLogger = new();
        private readonly Mock<LoggerHelper> _mockHelper = new();

        [Fact]
        public async Task GetMarathonById_CheckIfCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetMarathonByIdCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper.Setup(h => h.LogControllerAndAction(It.IsAny<MarathonController>())).Returns("Mock logger message");

            var controller = new MarathonController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.GetMarathonById(58);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetMarathonByIdCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateMarathon_CheckIfCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreateMarathonCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper.Setup(h => h.LogControllerAndAction(It.IsAny<MarathonController>())).Returns("Mock logger message");

            var controller = new MarathonController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            var dto = new MarathonPutPostDto() { FirstUserId = 1 };

            // Act
            await controller.CreateMarathon(dto);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<CreateMarathonCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteMarathon_CheckIfCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteMarathonCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper.Setup(h => h.LogControllerAndAction(It.IsAny<MarathonController>())).Returns("mock logger message");
            var controller = new MarathonController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.DeleteMarathon(58);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<DeleteMarathonCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetAll_CheckIfCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllMarathonsQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper.Setup(h => h.LogControllerAndAction(It.IsAny<MarathonController>())).Returns("mock logger message");
            var controller = new MarathonController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.GetAll();

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetAllMarathonsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AddUserToMarathon_CheckIfCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<AddUserToMaratonCommand>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper.Setup(h => h.LogControllerAndAction(It.IsAny<MarathonController>())).Returns("mock logger message");
            var controller = new MarathonController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.AddUserToMarathon(58, 58);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<AddUserToMaratonCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CountMembers_CheckIfCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<CountMembersQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper.Setup(h => h.LogControllerAndAction(It.IsAny<MarathonController>())).Returns("mock logger message");
            var controller = new MarathonController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.CountMembers(58);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<CountMembersQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task AverageDistance_CheckIfCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<AverageDistanceQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper.Setup(h => h.LogControllerAndAction(It.IsAny<MarathonController>())).Returns("mock logger message");
            var controller = new MarathonController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.AverageDistance(58);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<AverageDistanceQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetMembers_CheckIfCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllMembersQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper.Setup(h => h.LogControllerAndAction(It.IsAny<MarathonController>())).Returns("mock logger message");
            var controller = new MarathonController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.GetMembers(58);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetAllMembersQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetUsersByDistance_CheckIfCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<UsersByDistanceQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper.Setup(h => h.LogControllerAndAction(It.IsAny<MarathonController>())).Returns("mock logger message");
            var controller = new MarathonController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.GetUsersByDistance(58);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<UsersByDistanceQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CheckProgress_CheckIfCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<CheckProgressQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper.Setup(h => h.LogControllerAndAction(It.IsAny<MarathonController>())).Returns("mock logger message");
            var controller = new MarathonController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.CheckProgress(58, 85);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<CheckProgressQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
