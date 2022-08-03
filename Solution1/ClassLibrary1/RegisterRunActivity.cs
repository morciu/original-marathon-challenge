using Domain.Menu;

namespace Domain
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
            string distance = Console.ReadLine();

            Console.Write("Time(H:m:s): ");
            string time = Console.ReadLine();

            return $"{distance},{time}";
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