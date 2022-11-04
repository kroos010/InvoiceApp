using InvoiceApp.Application.Models.Debtor;
using InvoiceApp.Core.Entities;

namespace InvoiceApp.Application.Services.Contracts;

public interface IDebtorService
{
    public Task<IEnumerable<DebtorResponseModel>> GetAllAsync();
    public Task<DebtorResponseModel>? GetByIdAsync(Guid id);
    public Task<CreateDebtorResponseModel> CreateAsync(CreateDebtorModel createDebtorModel);
    public Task<UpdateDebtorResponseModel> UpdateAsync(Guid id, UpdateDebtorModel updateDebtorModel);
    public Task DeleteAsync(Guid debtorId);
}