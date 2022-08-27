namespace InvoiceApp.Core.Entities;

public class Debtor
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public string HouseNumber { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Email { get; set; }
}