using ClassLibrary1;
using ClassLibrary1.Menu;
using System.Diagnostics;
using System.IO;

// Set up menus
IMenu currentMenu = new MainMenu();

// Set up User Input
string userInput;



// Load registered users
UserManager.LoadRegisteredUsers();

// Testing Input
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