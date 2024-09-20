using System.Security.Claims;

namespace Corso.WebApi.Helpers.InjectableHelpers
{
    /// <summary>
    /// Helper class for managing tokens.
    /// </summary>
    public class TokenHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenHelper"/> class.
        /// </summary>
        /// <param name="configuration">The configuration instance for accessing app settings.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor for retrieving request information.</param>
        public TokenHelper(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Checks if the current user is authorized based on role or id claim.
        /// </summary>
        /// <param name="roles">An array of role names to check for authorization.</param>
        /// <param name="id">The ID of the Operator/User to check for authorization.</param>
        /// <returns>True if authorized; otherwise, false.</returns>
        public bool IsAuthorized(string[]? roles = null, Guid? id = null)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext?.User?.Identity?.IsAuthenticated != true)
            {
                return false;
            }

            var user = httpContext.User;

            if (roles != null)
            {
                foreach (string role in roles)
                {
                    if (user.IsInRole(role))
                    {
                        return true;
                    }
                }
            }

            if (id != null)
            {
                Claim? idClaim = user.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

                if (idClaim != null && idClaim.Value == id.ToString())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
