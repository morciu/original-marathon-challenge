using Application.Abstract;
using Application.Users.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.QueryHandlers
{
    internal class GetUserActivityInfoQueryHandler : IRequestHandler<GetUserActivityInfoQuery, Dictionary<string, string>>
    {
        private readonly IUserRepository _repo;
        public GetUserActivityInfoQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task<Dictionary<string, string>> Handle(GetUserActivityInfoQuery request, CancellationToken cancellationToken)
        {
            // Access user's individual activity csv file
            Dictionary<string, string> result = new Dictionary<string, string>();

            return Task.FromResult(result);
        }
    }
}
