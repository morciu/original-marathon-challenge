using Application.Abstract;
using Application.Activities.Queries;
using Application.Activities.QueryHandlers;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ActivityHandlerTests
{
    public class GetAllUserActivitiesQueryHandler_Fixture
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();

        public async Task CheckIfUserActivitiesAreReturned()
        {
            // Arrange
            var request = new GetAllUserActivitiesQuery { UserId = 58 };
            _mockUnitOfWork.Setup(u => u.ActivityRepository.GetUserActivities(request.UserId, It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new List<Activity>()));
            var handler = new GetAllUserActivitiesQueryHandler(_mockUnitOfWork.Object);

            // Act
            var result = await handler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            Assert.IsType<List<Activity>>(result);
        }
    }
}
