using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Application.Models.Debtor;

public class CreateDebtorModel
{
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    public string FirstName { get; set; }
    
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    public string LastName { get; set; }
    
    [Required]
    [MinLength(4)]
    [MaxLength(20)]
    public string CompanyName { get; set; }
    
    [Required]
    [MinLength(4)]
    public string Address { get; set; }
    
    [Required]
    [MinLength(1)]
    [MaxLength(5)]
    public string HouseNumber { get; set; }
    
    [Required]
    [MinLength(1)]
    public string ZipCode { get; set; }
    
    [Required]
    [MinLength(1)]
    public string City { get; set; }
    
    [Required]
    [MinLength(1)]
    public string Country { get; set; }
    
    [Required]
    [MinLength(1)]
    public string Email { get; set; }
}

public class CreateDebtorResponseModel : BaseResponseModel { }