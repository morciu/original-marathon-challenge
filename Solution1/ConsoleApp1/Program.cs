using ClassLibrary1;
using ClassLibrary1.Menu;
using System.Diagnostics;

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
    try
    {
        userInput = currentMenu.GetInput();
    }
    catch(Exception ex)
    {
        Console.WriteLine("Invalid Input");
        continue;
    }
#if DEBUG
    finally
    {
        Debug.WriteLine("Finalized Input Evaluation");
    }
#endif
    currentMenu.SwitchMenu(userInput, ref currentMenu);
    Console.WriteLine(currentMenu.GetState());
}