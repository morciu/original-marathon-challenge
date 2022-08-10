namespace ConsolePresentation.Menu
{
    public class MarathonProgressMenu : IMenu
    {
        private IMenu nextMenu;
        public void DisplayMenu()
        {
            //Console.WriteLine(CurrentUser.currentUser.activity.ShowProgress());
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