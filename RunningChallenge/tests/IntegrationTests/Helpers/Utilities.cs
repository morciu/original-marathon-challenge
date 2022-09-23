using Domain.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext db)
        {
            // Test distance values
            decimal[] distances = { 2.44m, 5.33m, 7.89m, 24.22m, 11.01m, 20.59m };
            string[] durations = { "00:04:55", "00:10:11", "01:03:05", "02:14:56", "00:59:59", "01:44:31" };


            // Add users
            db.Users.Add(new User
            {
                FirstName = "Buffy",
                LastName = "Summers",
                UserName = "buffy",
                Password = "mrpointy",
            });

            db.Users.Add(new User
            {
                FirstName = "Willow",
                LastName = "Rosenberg",
                UserName = "willow",
                Password = "abracadabra",
            });

            db.Users.Add(new User
            {
                FirstName = "Alexander",
                LastName = "Harris",
                UserName = "xander",
                Password = "vampiressucks",
            });

            // Add activities
            foreach(var user in db.Users)
            {
                db.Activities.Add(new Activity
                {
                    UserId = user.Id,
                    User = user,
                    Distance = distances[new Random().Next(0, distances.Length)],
                    Duration = TimeSpan.Parse(durations[new Random().Next(0, durations.Length)]),
                });

                db.Activities.Add(new Activity
                {
                    UserId = user.Id,
                    User = user,
                    Distance = distances[new Random().Next(0, distances.Length)],
                    Duration = TimeSpan.Parse(durations[new Random().Next(0, durations.Length)]),
                });

                db.Activities.Add(new Activity
                {
                    UserId = user.Id,
                    User = user,
                    Distance = distances[new Random().Next(0, distances.Length)],
                    Duration = TimeSpan.Parse(durations[new Random().Next(0, durations.Length)]),
                });
            }

            db.SaveChanges();
        }
    }
}
