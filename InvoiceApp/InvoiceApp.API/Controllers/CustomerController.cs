using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IEnumerable<string> Get() => new string[] { "John Doe", "Jane Doe" };
}