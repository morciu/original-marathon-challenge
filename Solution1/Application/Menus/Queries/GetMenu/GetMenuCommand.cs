using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Menu;
using MediatR;

namespace Application.Menus.Queries.GetMenu
{
    public class GetMenuCommand : IRequest<IMenu>
    {
        public int Id { get; set; }
    }
}
