using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InvoiceApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InvoiceApp.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpPost, Route("Login")]
    public IActionResult Login([FromBody] LoginModel user)
    {
        if (user == null)
        {
            return BadRequest("Invalid client request");
        }

        if (user.UserName == "johndoe" && user.Password == "1234")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VerySecretKey123!"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:7178",
                audience: "https://localhost:7178",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString });
        }

        return Unauthorized();
    }
}