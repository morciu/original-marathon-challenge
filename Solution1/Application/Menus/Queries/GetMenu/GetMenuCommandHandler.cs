using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.Menu;

namespace Application.Menus.Queries.GetMenu
{
    internal class GetMenuCommandHandler : IRequestHandler<GetMenuCommand, IMenu>
    {
        private readonly IMenuRepository _menuRepository;

        public GetMenuCommandHandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public Task<IMenu> Handle(GetMenuCommand request, CancellationToken cancellationToken)
        {
            var result = _menuRepository.GetMenu(request.Id);

            return Task.FromResult(result);
        }
    }
}
