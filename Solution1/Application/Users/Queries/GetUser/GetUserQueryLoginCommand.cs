using Domain.Entities;
using MediatR;

namespace Application.Users.Queries.GetUser
{
    public class GetUserQueryLoginCommand : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
