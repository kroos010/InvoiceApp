using InvoiceApp.Application.Models;
using InvoiceApp.Application.Models.User;
using InvoiceApp.Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.API.Controllers;

[ApiController]
[Route("api/auth")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Signup")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync(CreateUserModel createUserModel)
    {
        return Ok(ApiResult<CreateUserResponseModel>.Success(await _userService.CreateAsync(createUserModel)));
    }

    [HttpPost("Authenticate")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody]LoginUserModel loginUserModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        return Ok(ApiResult<LoginResponseModel>.Success(await _userService.LoginAsync(loginUserModel)));
    }

    // [HttpPost("confirmEmail")]
    // public async Task<IActionResult> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel)
    // {
    //     return Ok(ApiResult<ConfirmEmailResponseModel>.Success(
    //         await _userService.ConfirmEmailAsync(confirmEmailModel)));
    // }
    //
    // [HttpPut("{id:guid}/changePassword")]
    // public async Task<IActionResult> ChangePassword(Guid id, ChangePasswordModel changePasswordModel)
    // {
    //     return Ok(ApiResult<BaseResponseModel>.Success(
    //         await _userService.ChangePasswordAsync(id, changePasswordModel)));
    // }
}