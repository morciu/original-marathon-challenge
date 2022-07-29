using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class User
    {
        public int ID { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        private string _password;
        public string TotalDistance { get; }

        public User(int id, string firstName, string lastName, string userName, string password)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            _password = password;
        }

        // Properties
      /*  public int Id { get { return _id; } }
        public string FirstName { get { return _firstName; } }
*/
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
