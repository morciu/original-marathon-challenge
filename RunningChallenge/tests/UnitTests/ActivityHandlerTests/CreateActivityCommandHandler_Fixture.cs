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
    public class CreateActivityCommandHandler_Fixture
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
        private readonly Mock<IActivityRepository> _mockActivityRepo = new();

        [Fact]
        public async Task CheckIf_ActivityCreated()
        {
            // Arrange
            var request = new CreateActivityCommand
            {
                RunnerId = 58,
                Distance = 5.54m,
                Date = DateTime.Now,
                Duration = TimeSpan.Parse("00:24:33")
            };

            var activityList = new List<Activity>();


            _mockUnitOfWork.Setup(u => u.ActivityRepository.CreateActivity(It.IsAny<Activity>())).Callback(() =>
                {
                    activityList.Add(new Activity());
                });

            var handler = new CreateActivityCommandHandler(_mockUnitOfWork.Object);

            // Act
            await handler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            Assert.NotEmpty(activityList);
        }
    }
}
