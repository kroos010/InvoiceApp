using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.API.Models;

public class LoginModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
}