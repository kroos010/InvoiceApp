using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
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
[AllowAnonymous]
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
    public async Task<IActionResult> GetAllDebtors()
    {
        var debtors = await _debtorService.GetAllAsync();
        
        return Ok(debtors);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDebtorById(Guid id)
    {
        DebtorResponseModel debtor = await _debtorService.GetByIdAsync(id);
        if (debtor == null)
        {
            return NotFound($"Debtor with id: {id} does not exist.");
        }
        
        return Ok(debtor);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateDebtor(CreateDebtorModel createDebtorModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        var createdDebtor = await _debtorService.CreateAsync(createDebtorModel);
        
        return CreatedAtAction(nameof(GetAllDebtors),
            new { id = createdDebtor.Id }, createdDebtor);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateDebtor(Guid id, [FromBody]UpdateDebtorModel updateDebtorModel)
    {
        await _debtorService.UpdateAsync(id, updateDebtorModel);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDebtor(Guid id)
    {
        if (_debtorService.GetByIdAsync(id) == null)
        {
            return NotFound();
        }

        await _debtorService.DeleteAsync(id);

        return new NoContentResult();
    }
}