using ClassLibrary1;

// Set up menus
IMenu currentMenu = new MainMenu();

// Set up User Input
string userInput;

// Add default users
UserManager.CreateUser("Marian", "Pralea", "marian", "1234");
UserManager.CreateUser("Someone", "McSomeone", "someone", "1234");

// Main Flow
while (true)
{
    currentMenu.DisplayMenu();
    userInput = currentMenu.GetInput();
    currentMenu.SwitchMenu(userInput, ref currentMenu);
    Console.WriteLine(currentMenu.GetState());
}