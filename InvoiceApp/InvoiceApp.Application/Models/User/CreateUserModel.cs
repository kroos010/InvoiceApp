using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Application.Models.User;

public class CreateUserModel
{
    // [Required(AllowEmptyStrings = false)]
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}

public class CreateUserResponseModel : BaseResponseModel { }