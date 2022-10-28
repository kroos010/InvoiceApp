using FluentValidation;
using FluentValidation.Results;
using InvoiceApp.Application.Models;
using InvoiceApp.Application.Models.Debtor;
using InvoiceApp.Application.Models.User;
using InvoiceApp.Application.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.API.Controllers;

[ApiController]
[Route("api/debtor")]
public class DebtorController : ControllerBase
{
    private readonly IValidator<CreateDebtorModel> _createDebtorValidator;
    private readonly IValidator<UpdateDebtorModel> _updateDebtorValidator;
    
    private readonly IDebtorService _debtorService;
    
    public DebtorController(IValidator<CreateDebtorModel> createDebtorValidator, IValidator<UpdateDebtorModel> updateDebtorValidator, IDebtorService debtorService)
    {
        _createDebtorValidator = createDebtorValidator;
        _updateDebtorValidator = updateDebtorValidator;
        _debtorService = debtorService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllDebtors()
    {
        var test = await _debtorService.GetAllAsync();
        return Ok(ApiResult<IEnumerable<DebtorResponseModel>>.Success(await _debtorService.GetAllAsync()));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetAllDebtors(Guid id)
    {
        DebtorResponseModel debtor = await _debtorService.GetByIdAsync(id);

        if (debtor == null)
        {
            return NotFound(ApiResult<DebtorResponseModel>.Failure("Resource not found"));
        }
        
        return Ok(ApiResult<DebtorResponseModel>.Success(debtor));
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResult<CreateDebtorResponseModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateDebtorModel createDebtorModel)
    {
        ValidationResult result = await _createDebtorValidator.ValidateAsync(createDebtorModel);
        if (!result.IsValid)
        {
            foreach (var item in result.Errors)
            {
                this.ModelState.AddModelError(item.ErrorCode, item.ErrorMessage);
            }
        }
        
        // Todo: Update to created at action
        return Ok(ApiResult<CreateDebtorResponseModel>.Success(await _debtorService.CreateAsync(createDebtorModel)));
    }
    
    [HttpPut]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]UpdateDebtorModel updateDebtorModel)
    {
        ValidationResult result = await _updateDebtorValidator.ValidateAsync(updateDebtorModel);
        if (!result.IsValid)
        {
            foreach (var item in result.Errors)
            {
                this.ModelState.AddModelError(item.ErrorCode, item.ErrorMessage);
            }
        }

        await _debtorService.UpdateAsync(id, updateDebtorModel);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        if (_debtorService.GetByIdAsync(id) == null)
        {
            return NotFound();
        }
        
        return NotFound();
    }
}