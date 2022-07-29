namespace ClassLibrary1
{
    public static class UserManager
    {
        private static int _nrOfUsers ;

        public static User CreateUser(string firstName, string lastName, string userName, string password)
        {
            // Increment nr. of users
            _nrOfUsers++;
            return new User(_nrOfUsers, firstName, lastName, userName, password);
        }

        public static int NrOfUsers { get; }
    }
}