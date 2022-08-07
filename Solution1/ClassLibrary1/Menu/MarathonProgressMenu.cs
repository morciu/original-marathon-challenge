using Domain;

namespace Domain.Menu
{
    public class MarathonProgressMenu : IMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine(UserManager.currentUser.activity.ShowProgress());
            Console.WriteLine("1.Go Back\n0.Exit");
        }

        public string GetInput()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (input == "1" || input == "0")
                {
                    return input;
                }
            }
        }

        public string GetState()
        {
            return "marathonProgressMenu";
        }

        public void SwitchMenu(string input, ref IMenu menu)
        {
            if (input == "1") { menu = new UserMenu(); }
            else if (input == "0") { Environment.Exit(0); }
        }
    }
}