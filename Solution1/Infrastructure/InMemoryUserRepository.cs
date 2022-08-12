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
        private string _registeredUsers = SetUpFilePath().Item1;
        private string _registeredUsersFolder = SetUpFilePath().Item2;
        public void CreateUser(User user)
        {
            int nextUserId;
            try { nextUserId = GetNextUserId(); }
            catch(FileNotFoundException) { nextUserId = 0; }
            

            // Store registered user in registeredUsers.csv
            using (var sw = new StreamWriter(_registeredUsers, true))
            {
                sw.WriteLine($"{nextUserId},{user.FirstName},{user.LastName},{user.UserName},{user._password}");
            }

            // Create individual csv file for each user storing their data
            using (var sw = new StreamWriter(Path.Combine(_registeredUsersFolder, $"{nextUserId}.csv")))
            {
                sw.WriteLine("activity,none");
                sw.WriteLine("totalDistance,0");
                sw.WriteLine("activityIds,");
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

        public Dictionary<string, string> GetUserActivityInfo(int Id)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string filePath = Path.Combine(_registeredUsersFolder, Id.ToString() + ".csv");
            // store file content in dictionary
            using(var sr = new StreamReader(filePath))
            {
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    string[] lineArray = line.Split(",");
                    result.Add(lineArray[0], lineArray[1]);
                }
            }

            return result;
        }

        public void UpdateUserActivity(int id, string field, string value)
        {
            string filePath = Path.Combine(_registeredUsersFolder, id.ToString()+".csv");
            // Store all lines in an array
            string[] fileLines = File.ReadAllLines(filePath);
            // Find line that needs to be edited and modify fileLines
            for (int i = 0; i < fileLines.Length; i++)
            {
                string[] lineArray = fileLines[i].Split(",");
                if (lineArray[0] == field)
                {
                    fileLines[i] = $"{field},{value}";
                }
            }
            // Overwrite file with updated text
            File.WriteAllLines(filePath, fileLines);
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
        private static (string, string) SetUpFilePath()
        {
            string registeredUserPath = Path.Combine(Directory.GetCurrentDirectory(), "Registered Users");
            if (!Directory.Exists(registeredUserPath))
            {
                Directory.CreateDirectory(registeredUserPath);
            }
            var registeredUsers = Path.Combine(registeredUserPath, "registeredUsers.csv");
            return (registeredUsers,registeredUserPath);
        }
    }
}
