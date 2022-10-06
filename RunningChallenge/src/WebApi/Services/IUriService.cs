using WebApi.Filter;

namespace WebApi.Services
{
    // Responsible with building URLs based on pagination filter
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
