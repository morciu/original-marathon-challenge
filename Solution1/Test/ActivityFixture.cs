using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ActivityFixture
    {
        private readonly Mock<User> _mockUser = new();
        [Fact]
        public void CalculatePace_CalculatesAndReturnsCorrectPace()
        {
            // Arrange
            Activity activity = new Activity { Id = 1, Duration = TimeSpan.Parse("00:55:51"), Date = DateTime.Now, User = _mockUser.Object, Distance = 10.98m };

            // Act
            var pace = activity.CalculatePace(activity.Distance, activity.Duration);

            // Assert
            Assert.Equal(pace, TimeSpan.Parse("00:05:05"));
        }
    }
}
