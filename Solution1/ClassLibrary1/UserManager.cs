namespace Domain
{
    public static class UserManager
    {
        // Current user
        public static User currentUser;

        // Registered Users
        public static List<User> users = new List<User>();

        public static User CreateUser(string firstName, string lastName, string userName, string password)
        {
            // Add to registered User List
            SaveUserLocally(users.Count + 1, firstName, lastName, userName, password);
            User newUser = new User(users.Count + 1, firstName, lastName, userName, password);
            users.Add(newUser);
            return newUser;
        }

        public static void SaveUserLocally(int id, string firstName, string lastName, string userName, string password)
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
                sw.WriteLine($"{users.Count + 1},{firstName},{lastName},{userName},{password}");
            }
        }
        public static void LoadRegisteredUsers()
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

                        User newUser = new User(int.Parse(infoArray[0]), infoArray[1], infoArray[2], infoArray[3], infoArray[4]);
                        users.Add(newUser);
                    }
                }
            }
        }


        public static bool ValidateUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (username == user.UserName && user.ValidatePassword(password))
                {
                    currentUser = user;
                    return true;
                }
            }
            return false;
        }
    }
}