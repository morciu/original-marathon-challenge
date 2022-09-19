using Domain.Models;
using MediatR;

namespace Application.Users.Queries
{
    public class GetUserQueryLoginCommand : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
