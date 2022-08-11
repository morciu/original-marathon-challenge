using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    internal class CheckProgress : Menu
    {
        public CheckProgress(AppState app) : base(app)
        {
            Message = "Marathon Progress";
            Options = new string[2] {"Go Back", "Exit" };
        }

        public override void InteractWithUser()
        {
            Console.WriteLine("Checking Marathon progress");
            Console.ReadLine();
        }
    }
}
