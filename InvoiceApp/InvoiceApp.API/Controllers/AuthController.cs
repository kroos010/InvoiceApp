using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InvoiceApp.API.Data;
using InvoiceApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InvoiceApp.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly UserManager<Account> _userManager;
    private readonly SignInManager<Account> _signInManager;


    public AuthController(ApplicationContext context, UserManager<Account> userManager, SignInManager<Account> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // private async Task<Account> GetUser(string email, string password)
    // {
    //     return await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    // }

    [HttpPost, Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginModel user)
    {
        if (user == null || !ModelState.IsValid)
        {
            return BadRequest("Invalid client request");
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);
        if (result.Succeeded)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VerySecretKey123!"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var userd = await _userManager.FindByEmailAsync(user.UserName);

            // var claims = new[] {
            //             new Claim(JwtRegisteredClaimNames.Sub, ""),
            //             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //             new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            //             new Claim("UserId", userd.Id.ToString()),
            //         };

            var id = userd.Id;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userd.Id),
                new Claim(ClaimTypes.NameIdentifier, userd.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                        DateTime.UtcNow.ToString(),
                        ClaimValueTypes.Integer64),
                        new Claim("Claim", "Value")
            };

            DateTime tokenExpiration = DateTime.Now.AddMinutes(15);

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:7178",
                audience: "https://localhost:7178",
                // claims: new List<Claim>(),
                claims: claims,
                expires: tokenExpiration,
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            // return Ok(new { Token = tokenString });
            return Ok(new { Token = tokenString, TokenExpiration = tokenExpiration });
        }

        // if (user.UserName == "johndoe" && user.Password == "1234")
        // {
        //     var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VerySecretKey123!"));
        //     var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        //     var tokenOptions = new JwtSecurityToken(
        //         issuer: "https://localhost:7178",
        //         audience: "https://localhost:7178",
        //         claims: new List<Claim>(),
        //         expires: DateTime.Now.AddMinutes(5),
        //         signingCredentials: signingCredentials
        //     );

        //     var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //     return Ok(new { Token = tokenString });
        // }

        return Unauthorized();
    }

    [HttpPost, Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
    {
        if (registerModel == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        Account account = new Account
        {
            UserName = registerModel.Email,
            Email = registerModel.Email,
            FirstName = registerModel.FirstName,
            LastName = registerModel.LastName,
        };

        var result = await _userManager.CreateAsync(account, registerModel.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors;
            return BadRequest(errors);
        }

        return StatusCode(201);
    }

    public class TokenModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("stringhier")),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;

    }

    [Authorize]
    [HttpPost, Route("RefreshToken")]
    public async Task<IActionResult> RefreshToken()
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VerySecretKey123!"));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var userId = HttpContext.GetUserId();
        var userd = await _userManager.FindByIdAsync(userId);

        var id = userd.Id;
        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userd.Id),
                new Claim(ClaimTypes.NameIdentifier, userd.Id),
                new Claim(ClaimTypes.Name, userd.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                        DateTime.UtcNow.ToString(),
                        ClaimValueTypes.Integer64),
                        new Claim("Claim", "Value")
            };

        DateTime tokenExpiration = DateTime.Now.AddMinutes(15);

        var tokenOptions = new JwtSecurityToken(
            issuer: "https://localhost:7178",
            audience: "https://localhost:7178",
            // claims: new List<Claim>(),
            claims: claims,
            expires: tokenExpiration,
            signingCredentials: signingCredentials
        );


        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        // return Ok(new { Token = tokenString });
        return Ok(new { Token = tokenString, TokenExpiration = tokenExpiration });
    }
}