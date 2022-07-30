using Microsoft.AspNetCore.Identity;

namespace InvoiceApp.API.Data;

public class Account : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}