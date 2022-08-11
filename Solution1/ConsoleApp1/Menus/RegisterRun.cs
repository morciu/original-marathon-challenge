using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    internal class RegisterRun : Menu
    {
        public RegisterRun(AppState app) : base(app)
        {
            Message = "Enter your last run";
            Options = new string[2] { "Distance: ", "Time: " };
        }

        public override void InteractWithUser()
        {
            Console.WriteLine(Message);
            Console.ReadLine();
        }
    }
}
