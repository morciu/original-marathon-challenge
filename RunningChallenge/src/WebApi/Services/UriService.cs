using Microsoft.AspNetCore.WebUtilities;
using WebApi.Filter;

namespace WebApi.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri; // get base rul (in this case localhost)

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            // Join URI with route to make new URI
            var _endpointUri = new Uri(string.Concat(_baseUri, route));
            // Add new query string pageNumber
            var modifiedUri = QueryHelpers.AddQueryString(
                _endpointUri.ToString(), "pageNumber", filter.PageNumber.ToString()
                );
            // Add new query string pageSize
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", filter.PageSize.ToString());

            return new Uri(modifiedUri);
        }
    }
}
