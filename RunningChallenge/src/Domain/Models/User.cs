using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; } = null!;

        [MaxLength(20)] 
        public string LastName { get; set; } = null!;

        [MaxLength(20)]
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public ICollection<Activity> Activities { get; set; } = null!;
        public ICollection<Marathon> Marathons { get; set; } = null!;
        /*
                public User(int id, string firstName, string lastName, string userName, string password)
                {
                    Id = id;
                    FirstName = firstName;
                    LastName = lastName;
                    UserName = userName;
                    Password = password;
                }*/

        public void RunActivity()
        {
            throw new NotImplementedException();
        }

        public void StartMarathon()
        {
            /*activity = new Marathon();*/
        }

        public decimal CalculateTotalDistance()
        {
            decimal totalDistance = 0;
            foreach (var activity in Activities)
            {
                totalDistance += activity.Distance;
            }
            return totalDistance;
        }
    }
}
