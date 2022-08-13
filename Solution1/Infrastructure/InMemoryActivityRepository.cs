using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain;

namespace Infrastructure
{
    public class InMemoryActivityRepository : IActivityRepository
    {
        public void CreateActivity(string id, string distance, string date, string duration)
        {
            // Store each activity in activities.csv - runnerId,distance,date,duration
            string activitiesFile = Path.Combine(Directory.GetCurrentDirectory(), "activities.csv");
            using(var sr = new StreamWriter(activitiesFile, true))
            {
                sr.WriteLine($"{id},{distance},{date},{duration}");
            }
        }
    }
}
