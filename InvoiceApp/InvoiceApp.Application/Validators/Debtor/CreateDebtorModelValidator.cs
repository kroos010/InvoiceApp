using FluentValidation;
using InvoiceApp.Application.Models.Debtor;
using InvoiceApp.Application.Models.User;

namespace InvoiceApp.Application.Validators.Debtor;

public class CreateDebtorModelValidator : AbstractValidator<CreateDebtorModel>
{
    public CreateDebtorModelValidator()
    {
        RuleFor(d => d.FirstName)
            .NotEmpty().WithErrorCode("Firstname").WithMessage($"Firstname should not be empty")
            .MinimumLength(4).WithErrorCode("Firstname").WithMessage($"Firstname should have minimum 4 characters")
            .MaximumLength(20).WithErrorCode("Firstname").WithMessage($"Firstname should have maximum 20 characters");
    }
}