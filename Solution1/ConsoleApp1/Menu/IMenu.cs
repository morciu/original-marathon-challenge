using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Menu
{
    public interface IMenu
    {
        public string DisplayMenu();
        public IMenu SwitchMenu();
        public string ProcessFlag();
    }
}
