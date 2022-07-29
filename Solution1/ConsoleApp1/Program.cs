using ClassLibrary1;

// Set up menus
MainMenu mainMenu = new MainMenu();

// Show Main Menu
mainMenu.DisplayMenu();

// Check user input
Console.WriteLine(mainMenu.GetInput());

User user = UserManager.CreateUser("Marian", "Pralea", "marian", "1234");
Console.WriteLine($"User {user.UserName}\nid: {user.ID}\nfull name: {user.FirstName} {user.LastName}");