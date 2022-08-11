using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain;

namespace Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        private string _registeredUsers = SetUpFilePath();
        public void CreateUser(User user)
        {
            int nextUserId = GetNextUserId();

            using (var sw = new StreamWriter(_registeredUsers, true))
            {
                sw.WriteLine($"{nextUserId},{user.FirstName},{user.LastName},{user.UserName},{user._password}");
            }
        }

        public User? GetUser(int userId)
        {
            if (File.Exists(_registeredUsers))
            {
                using (var sr = new StreamReader(_registeredUsers))
                {
                    while (true)
                    {
                        var userInfo = sr.ReadLine();
                        if (userInfo == null)
                        {
                            break;
                        }
                        string[] infoArray = userInfo.Split(",");

                        if (int.Parse(infoArray[0]) == userId)
                        {
                            return new User(int.Parse(infoArray[0]), infoArray[1], infoArray[2], infoArray[3], infoArray[4]);
                        }
                    }
                }
            }
            return null;
        }
        public User GetUserByLogin(string userName, string password)
        {
            using (var sr = new StreamReader(_registeredUsers))
            {
                while (true)
                {
                    var userInfo = sr.ReadLine();
                    if (userInfo == null)
                    {
                        break;
                    }
                    string[] infoArray = userInfo.Split(",");
                    if (infoArray[3] == userName && infoArray[4] == password)
                    {
                        return new User(int.Parse(infoArray[0]), infoArray[1], infoArray[2], infoArray[3], infoArray[4]);
                    }
                }
            }
            return null;
        }
        public int GetNextUserId()
        {
            int idCount = 1;
            using(var sr = new StreamReader(_registeredUsers))
            {
                while(sr.ReadLine() != null)
                {
                    idCount++;
                }
            }
            return idCount;
        }
        private static string SetUpFilePath()
        {
            string registeredUserPath = Path.Combine(Directory.GetCurrentDirectory(), "Registered Users");
            if (!Directory.Exists(registeredUserPath))
            {
                Directory.CreateDirectory(registeredUserPath);
            }
            var registeredUsers = Path.Combine(registeredUserPath, "registeredUsers.csv");
            return registeredUsers;
        }
    }
}
