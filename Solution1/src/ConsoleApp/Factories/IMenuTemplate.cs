using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Factories
{
    internal interface IMenuTemplate
    {
        string Message { get; set; }
        string[] Options { get; set; }
        int UserSelection { get; set; }
        string[] UserInput { get; set; }
        void RunMenu();
    }
}
