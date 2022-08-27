using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Application.Models.User;

public class LoginUserModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}

public class LoginResponseModel
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Token { get; set; }
}