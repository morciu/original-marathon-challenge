using ClassLibrary1;

// Set up menus
IMenu currentMenu = new MainMenu();

// Set up User Input
string userInput;

// Main Flow
while (true)
{
    currentMenu.DisplayMenu();
    userInput = currentMenu.GetInput();
    currentMenu.SwitchMenu(userInput, ref currentMenu);
    Console.WriteLine(currentMenu.GetState());
}