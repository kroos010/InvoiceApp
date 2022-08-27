namespace InvoiceApp.Shared.Services.Contracts;

public interface IClaimService
{
    string GetUserId();

    string GetClaim(string key);
}