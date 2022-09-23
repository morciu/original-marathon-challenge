﻿using Application.Abstract;
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
    public class AddActivityToUserHandler_Fixture
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new();
        private readonly Mock<IUserRepository> _mockUserRepo = new();
        private readonly Mock<IActivityRepository> _mockActivityRepo = new();

        [Fact]
        public async Task CheckIf_ValidActivity_AddedTo_ValidUsers()
        {
            // Arrange
            var request = new AddActivityToUser { ActivityId = 85, UserId = 58 };

            var user = new User
            {
                Id = request.UserId,
                FirstName = "John",
                LastName = "Doe",
                UserName = "testUser",
                Activities = new List<Activity>(),
                Marathons = new List<Marathon>()
            };
            _mockUnitOfWork.Setup(u => u.UserRepository.GetUser(request.UserId)).Returns(Task.FromResult(user));

            var activity = new Activity
            {
                Id = request.ActivityId,
                UserId = user.Id,
                User = user,
                Distance = 11.11m,
                Date = DateTime.Now,
                Duration = TimeSpan.Parse("01:01:22"),
            };
            _mockUnitOfWork.Setup(a => a.ActivityRepository.GetActivityById(request.ActivityId)).Returns(Task.FromResult(activity));

            var handler = new AddActivityToUserHandler(_mockUnitOfWork.Object);

            // Act

            var result = await handler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            Assert.IsType<User>(result);
        }

        [Fact]
        public async Task CheckIf_NullActivity_NotAddedTo_ValidUser()
        {
            // Arrange
            var request = new AddActivityToUser { ActivityId = 85, UserId = 58 };

            var user = new User
            {
                Id = request.UserId,
                FirstName = "John",
                LastName = "Doe",
                UserName = "testUser",
                Activities = new List<Activity>(),
                Marathons = new List<Marathon>()
            };
            _mockUnitOfWork.Setup(u => u.UserRepository.GetUser(request.UserId)).Returns(Task.FromResult(user));

            _mockUnitOfWork.Setup(a => a.ActivityRepository.GetActivityById(request.ActivityId)).Returns(Task.FromResult<Activity>(null));

            var handler = new AddActivityToUserHandler(_mockUnitOfWork.Object);

            // Act

            var result = await handler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CheckIf_ValidActivity_NotAddedTo_NullUser()
        {
            // Arrange
            var request = new AddActivityToUser { ActivityId = 85, UserId = 58 };
            _mockUnitOfWork.Setup(u => u.UserRepository.GetUser(request.UserId)).Returns(Task.FromResult<User>(null));

            var activity = new Activity
            {
                Id = request.ActivityId,
                UserId = request.UserId,
                User = null,
                Distance = 11.11m,
                Date = DateTime.Now,
                Duration = TimeSpan.Parse("01:01:22"),
            };
            _mockUnitOfWork.Setup(a => a.ActivityRepository.GetActivityById(request.ActivityId)).Returns(Task.FromResult(activity));

            var handler = new AddActivityToUserHandler(_mockUnitOfWork.Object);

            // Act

            var result = await handler.Handle(request, It.IsAny<CancellationToken>());

            // Assert
            Assert.Null(result);
        }
    }
}
