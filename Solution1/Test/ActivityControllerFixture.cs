﻿using Application.Activities.Queries;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using WebAPI.Controllers;
using WebAPI.ControllersHelpers;

namespace Test
{
    public class ActivityControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new();
        private readonly Mock<IMapper> _mockMapper = new();
        private readonly Mock<ILogger<ActivityController>> _mockLogger = new();
        private readonly Mock<ControllerHelper> _mockHelper = new();

        [Fact]
        public async Task Get_All_GetAllIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllActivitiesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();
            _mockHelper
                .Setup(h => h.GetControllerName(It.IsAny<ActivityController>())).Returns("ActivityControllerTest");
            _mockHelper
                .Setup(h => h.GetActionName(It.IsAny<ActivityController>())).Returns("GetAllTest");

            var controller = new ActivityController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

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
                .Setup(h => h.GetControllerName(It.IsAny<ActivityController>())).Returns("ActivityControllerTest");
            _mockHelper
                .Setup(h => h.GetActionName(It.IsAny<ActivityController>())).Returns("GetActivityByIdTest");

            var controller = new ActivityController(_mockMediator.Object, _mockMapper.Object, _mockLogger.Object, _mockHelper.Object);

            // Act
            await controller.GetActivityById(5);

            // Assert
            _mockMediator.Verify(m => m.Send(It.IsAny<GetActivityByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
