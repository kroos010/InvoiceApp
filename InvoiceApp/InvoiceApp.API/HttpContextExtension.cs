using System.Security.Claims;
using System.Security.Principal;

namespace InvoiceApp.API
{
    public static class HttpContextExtension
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            return httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}