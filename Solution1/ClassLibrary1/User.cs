using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class User
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _password;
        private string _totalDistance;

        public User(int id, string firstName, string lastName, string userName, string password)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _userName = userName;
            _password = password;
        }

        public void RunActivity()
        {
            throw new NotImplementedException();
        }

        public void StartSharedMarathon()
        {
            throw new NotImplementedException();
        }
    }
}
