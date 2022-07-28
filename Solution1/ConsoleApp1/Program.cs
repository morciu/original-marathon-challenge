using ClassLibrary1;

// Set up menus
MainMenu mainMenu = new MainMenu();

// Show Main Menu
mainMenu.DisplayMenu();

// Check user input
Console.WriteLine(mainMenu.GetInput());