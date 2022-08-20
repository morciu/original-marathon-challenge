using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsolePresentation;
using ConsolePresentation.Menus;
using Domain;

namespace Test
{
    public class UserFixture
    {
        // Test created before method
        User user = new User(1, "firstName", "lastName", "userName", "password");

        [Fact]
        public void CalculateTotalDistanceCheckIfCorrect()
        {
            user.Activities = new List<Activity>()
            {
                new Activity(user.Id, 2.32m, new DateTime(2022, 8, 1), new TimeSpan(0, 10, 54)),
                new Activity(user.Id, 4.21m, new DateTime(2022, 8, 2), new TimeSpan(0, 21, 43)),
                new Activity(user.Id, 7.12m, new DateTime(2022, 8, 3), new TimeSpan(0, 49, 18)),
                new Activity(user.Id, 11.58m, new DateTime(2022, 8, 5), new TimeSpan(1, 8, 59)),
            };

            decimal result = user.CalculateTotalDistance();

            Assert.Equal(25.23m, result);
        }
    }
}
