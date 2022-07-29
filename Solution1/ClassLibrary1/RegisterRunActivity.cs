namespace ClassLibrary1
{
    internal class RegisterRunActivity : IMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Enter your most recent running activity");
        }

        public string GetInput()
        {
            Console.Write("Distance(km): ");
            string username = Console.ReadLine();

            Console.Write("Time(H:m:s): ");
            string password = Console.ReadLine();

            return $"{username},{password}";
        }

        public string GetState()
        {
            return "registerRunActivity";
        }

        public void SwitchMenu(string input, ref IMenu menu)
        {

            menu = new UserMenu();
        }
    }
}