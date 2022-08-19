using ConsolePresentation.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation.Factories
{
    internal class SelectionMenuFactory : IMenuTemplateFactory
    {
        public IMenuTemplate CreateMenuTemplate(string message, string[] options)
        {
            return new BlankSelectionMenu
            {
                Message = message,
                Options = options
            };
        }
    }
}
