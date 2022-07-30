using System.Security.Claims;
using System.Security.Principal;

namespace InvoiceApp.API
{
    public static class IdentityExtended
    {
        public static string GetFullName(this IIdentity identity)
        {
            IEnumerable<Claim> claims = ((ClaimsIdentity)identity).Claims;
            var FullName = claims.Where(c => c.Type == "FullName").SingleOrDefault();
            return FullName.Value;
        }
    }
}