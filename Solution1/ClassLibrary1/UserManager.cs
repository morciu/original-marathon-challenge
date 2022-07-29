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