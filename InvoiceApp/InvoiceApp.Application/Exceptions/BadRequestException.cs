namespace InvoiceApp.Application.Exceptions;

public class BadRequestException : Exception
{
    public String ErrorCode = "";

    public BadRequestException(string message) : base(message) { }
}