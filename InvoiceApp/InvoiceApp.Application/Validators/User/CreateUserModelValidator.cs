using FluentValidation;
using InvoiceApp.Application.Models.User;
using InvoiceApp.DataAccess.Identity;
using Microsoft.AspNetCore.Identity;

namespace InvoiceApp.Application.Validators.User;

public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CreateUserModelValidator(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;

        RuleFor(u => u.Email)
            .NotEmpty().WithErrorCode("Email").WithMessage($"Email should not be empty")
            .MinimumLength(4).WithErrorCode("Email").WithMessage($"Email should have minimum 4 characters")
            .MaximumLength(20).WithErrorCode("Email").WithMessage($"Email should have maximum 20 characters")
            .EmailAddress().WithErrorCode("Email").WithMessage("Should be a valid email")
            .MustAsync(UsernameIsUniqueAsync).WithErrorCode("DuplicateUserName").WithMessage("Email is not available");

        RuleFor(u => u.Password)
            .NotNull().WithErrorCode("Password").WithMessage("Password should not be empty")
            .MinimumLength(6).WithErrorCode("Password").WithMessage($"Password should have minimum 6 characters")
            .MaximumLength(100).WithErrorCode("Password").WithMessage($"Password should have maximum 100 characters");

        // RuleFor(u => u.Email)
        //     .EmailAddress()
        //     .WithMessage("Email address is not valid")
        //     .MustAsync(EmailAddressIsUniqueAsync)
        //     .WithMessage("Email address is already in use");
    }

    private async Task<bool> EmailAddressIsUniqueAsync(string email, CancellationToken cancellationToken = new())
    {
        var user = await _userManager.FindByEmailAsync(email);

        return user == null;
    }

    private async Task<bool> UsernameIsUniqueAsync(string username, CancellationToken cancellationToken = new())
    {
        var user = await _userManager.FindByNameAsync(username);

        return user == null;
    }
}