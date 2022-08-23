using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; }
        public string _password;
        public ICollection<Activity> Activities { get; set; } = null;
        public ICollection<Marathon> Marathon { get; set; } = null;

        public User(int id, string firstName, string lastName, string userName, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            _password = password;
        }

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
