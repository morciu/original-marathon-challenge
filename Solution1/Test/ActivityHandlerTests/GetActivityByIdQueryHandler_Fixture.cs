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
    public class GetActivityByIdQueryHandler_Fixture
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();

        [Fact]
        public async Task CheckActivityIsReturned()
        {
            // Arrange
            var request = new GetActivityByIdQuery { Id = 58 };
            var activity = new Activity { Id = request.Id };

            _mockUnitOfWork.Setup(u => u.ActivityRepository.GetActivityById(request.Id)).Returns(Task.FromResult(activity));

            var handler = new GetActivityByIdQueryHandler(_mockUnitOfWork.Object);

            // Act
            var result = await handler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            Assert.Equivalent(activity, result);
        }
    }
}
