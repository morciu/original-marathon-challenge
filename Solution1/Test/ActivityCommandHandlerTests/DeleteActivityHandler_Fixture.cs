using Application.Abstract;
using Application.Activities.CommandHandlers;
using Application.Activities.Commands;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ActivityCommandHandlerTests
{
    public class DeleteActivityHandler_Fixture
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();

        public async Task CheckIfActivityDeleted()
        {
            // Arrange
            var request = new DeleteActivity { Id = 58 };
            var activityList = new List<Activity>();
            var activity = new Activity { Id = request.Id };
            activityList.Add(activity);

            _mockUnitOfWork.Setup(u => u.ActivityRepository.Delete(It.IsAny<Activity>()))
                .Callback(() =>
                {
                    activityList.Remove(activity);
                });

            var handler = new DeleteActivityHandler(_mockUnitOfWork.Object);

            // Act
            await handler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            Assert.DoesNotContain(activity, activityList);
        }
    }
}
