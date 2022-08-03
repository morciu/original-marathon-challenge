using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int ID { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        private string _password;
        public string TotalDistance { get; }
        public Marathon activity;

        public User(int id, string firstName, string lastName, string userName, string password)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            _password = password;
        }

        public bool ValidatePassword(string passwordInput)
        {
            return _password == passwordInput ? true : false;
        }
        public void RunActivity()
        {
            throw new NotImplementedException();
        }

        public void StartMarathon()
        {
            activity = new Marathon();
        }

        public void StartSharedMarathon()
        {
            activity = new SharedPrivateMarathon();
        }
    }
}
