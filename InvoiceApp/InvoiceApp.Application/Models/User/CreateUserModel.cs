using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Application.Models.User;

public class CreateUserModel
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }

    [Required]
    public string Password { get; set; }
}

public class CreateUserResponseModel : BaseResponseModel { }