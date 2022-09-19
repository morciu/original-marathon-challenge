using ConsolePresentation.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Factories
{
    internal class InputMenuFactory : IMenuTemplateFactory
    {
        public IMenuTemplate CreateMenuTemplate(string message, string[] options)
        {
            return new BlankInputMenu
            {
                Message = message,
                Options = options
            };
        }
    }
}
