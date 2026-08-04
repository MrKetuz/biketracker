using Microsoft.AspNetCore.Mvc.Filters;

namespace BiketrackerBackend.Filters
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // No-op authorization implementation; replace with real checks as needed.
        }
    }
}
