namespace ClassLibrary1
{
    public static class UserManager
    {
        // Current user
        public static User currentUser;

        // Registered Users
        public static List<User> users = new List<User>();

        public static User CreateUser(string firstName, string lastName, string userName, string password)
        {
            User newUser = new User(users.Count+1, firstName, lastName, userName, password);

            // Add to registered User List
            users.Add(newUser);
            return newUser;
        }

        public static bool ValidateUser(string username, string password)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (username == users[i].UserName && users[i].ValidatePassword(password))
                {
                    return true;
                }
            }
            return false;
        }

        public static int NrOfUsers { get; }
    }
}