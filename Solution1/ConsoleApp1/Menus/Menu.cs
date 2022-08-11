using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menus
{
    public abstract class Menu
    {
        protected string Message { get; set; }
        protected string[] Options { get; set; }
        protected AppState App { get; set; }

        public Menu(AppState app)
        {
            App = app;
        }

        virtual public void InteractWithUser()
        {

        }
    }
}
