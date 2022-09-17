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
    public class GetAllActivitiesQueryHandler_Fixture
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();

        public async Task CheckIfAllActivitiesAreReturned()
        {
            // Arrange
            var request = new GetAllActivitiesQuery();
            var activityList = new List<Activity>()
            {
                new Activity{ Id = 1 },
                new Activity{ Id = 2 },
                new Activity{ Id = 3 },
            };
            _mockUnitOfWork.Setup(u => u.ActivityRepository.GetAllActivities()).Returns(Task.FromResult(activityList));

            var handler = new GetAllActivitiesQueryHandler(_mockUnitOfWork.Object);

            // Act
            var result = await handler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            Assert.Equal(activityList.Count, result.Count);
        }
    }
}
