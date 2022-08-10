
namespace ConsolePresentation.Menu
{
    internal class RegisterRunActivity : IMenu
    {
        private IMenu nextMenu;
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

        public string ProcessFlag()
        {
            throw new NotImplementedException();
        }

        public void ProcessInput(string input)
        {
        }

        public IMenu SwitchMenu()
        {
            return nextMenu;
        }

        string IMenu.DisplayMenu()
        {
            throw new NotImplementedException();
        }
    }
}