namespace ClassLibrary1
{
    public static class UserManager
    {
        public static int NrOfUsers;

        public static User CreateUser(string firstName, string lastName, string userName, string password)
        {
            // Increment nr. of users
            NrOfUsers++;
            return new User(NrOfUsers, firstName, lastName, userName, password);
        }
    }
}