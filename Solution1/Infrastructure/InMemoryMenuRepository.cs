using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain.Menu;

namespace Infrastructure
{
    public class InMemoryMenuRepository : IMenuRepository
    {
        private readonly Dictionary<int, IMenu> _menus = new Dictionary<int, IMenu>()
        {
            { 1, new MainMenu() },
            { 2, new UserRegistrationMenu() },
            { 3, new UserLogInMenu() },
            { 4, new UserMenu() },
            { 5, new MarathonProgressMenu() },
        };
        public IMenu? GetMenu(int menuId)
        {
            return _menus[menuId];
        }
    }
}
