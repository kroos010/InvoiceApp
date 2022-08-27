using Microsoft.AspNetCore.Identity;

namespace InvoiceApp.DataAccess.Identity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}