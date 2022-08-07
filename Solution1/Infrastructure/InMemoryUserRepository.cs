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
        public void CreateUser(User user)
        {
            FileStream fileStream = null;
            // Set up Registered users directory and txt file if one doesn't already exist
            var registeredUserPath = Path.Combine(Directory.GetCurrentDirectory(), "Registered Users");
            if (!Directory.Exists(registeredUserPath))
            {
                Directory.CreateDirectory(registeredUserPath);
            }
            var registeredUsers = Path.Combine(registeredUserPath, "registeredUsers.csv");

            using (var sw = new StreamWriter(registeredUsers, true))
            {
                sw.WriteLine($"{user.Id},{user.FirstName},{user.LastName},{user.UserName},{user._password}");
            }
        }

        public User? GetUser(int userId)
        {
            var registeredUserPath = Path.Combine(Directory.GetCurrentDirectory(), "Registered Users");
            var registeredUsers = Path.Combine(registeredUserPath, "registeredUsers.csv");
            if (File.Exists(registeredUsers))
            {
                using (var sr = new StreamReader(registeredUsers))
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
    }
}
