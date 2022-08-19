using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Factories
{
    internal interface IMenuTemplateFactory
    {
        IMenuTemplate CreateMenuTemplate(string message, string[] options);
    }
}
