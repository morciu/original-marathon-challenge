using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain.Models;

namespace Infrastructure.Repository
{
    public class InMemoryActivityRepository : IActivityRepository
    {
        public void CreateActivity(string id, string distance, string date, string duration)
        {
            // Store each activity in activities.csv - runnerId,distance,date,duration
            string activitiesFile = Path.Combine(Directory.GetCurrentDirectory(), "activities.csv");
            using (var sr = new StreamWriter(activitiesFile, true))
            {
                sr.WriteLine($"{id},{distance},{date},{duration}");
            }
        }

        public List<Activity> GetUserActivities(int userId)
        {
            List<Activity> activities = new List<Activity>();
            string activitiesFile = Path.Combine(Directory.GetCurrentDirectory(), "activities.csv");

            // Read through all locally registered activities and add the ones with userId to the activities list
            using (var sr = new StreamReader(activitiesFile))
            {
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    string[] activityInfo = line.Split(",");
                    if (activityInfo[0] == userId.ToString())
                    {
                        activities.Add(new Activity(
                            userId,
                            Convert.ToDecimal(activityInfo[1]),
                            DateTime.Parse(activityInfo[2]),
                            TimeSpan.Parse(activityInfo[3])
                            ));
                    }
                }
            }

            return activities;
        }
    }
}
