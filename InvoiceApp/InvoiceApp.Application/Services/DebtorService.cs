using AutoMapper;
using InvoiceApp.Application.Exceptions;
using InvoiceApp.Application.Models.Debtor;
using InvoiceApp.Application.Services.Contracts;
using InvoiceApp.Core.Entities;
using InvoiceApp.DataAccess.UnitOfWork.Contracts;

namespace InvoiceApp.Application.Services;

public class DebtorService : IDebtorService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public DebtorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DebtorResponseModel>> GetAllAsync()
    {
        var debtors = await _unitOfWork.Debtors.GetAsync();
        List<DebtorResponseModel> debtorsResponse = _mapper.Map<List<DebtorResponseModel>>(debtors);

        return debtorsResponse;
    }
    
    public async Task<DebtorResponseModel> GetByIdAsync(Guid id)
    {
        Debtor debtor = await _unitOfWork.Debtors.GetByIdAsync(id);
        
        if (debtor == null)
        {
            throw new NotFoundException("Not found");
        }
        
        DebtorResponseModel debtorResponse = _mapper.Map<DebtorResponseModel>(debtor);

        return debtorResponse;
    }
    
    public async Task<CreateDebtorResponseModel> CreateAsync(CreateDebtorModel createDebtorModel)
    {
        var debtor = _mapper.Map<Debtor>(createDebtorModel);
        var addedDebtor = _unitOfWork.Debtors.AddAsync(debtor);
        _unitOfWork.Complete();
        
        return new CreateDebtorResponseModel
        {
            Id = addedDebtor.Result.Id
        };
    }
    
    public async Task<UpdateDebtorResponseModel> UpdateAsync(Guid id, UpdateDebtorModel updateDebtorModel)
    {
        var debtor = await _unitOfWork.Debtors.GetFirstAsync(m => m.Id == id);
        if (debtor == null)
        {
            throw new NotFoundException("Not found");
        }
        
        _mapper.Map(updateDebtorModel, debtor);
        
        var updatedDebtor = _unitOfWork.Debtors.UpdateAsync(debtor);
        _unitOfWork.Complete();

        return new UpdateDebtorResponseModel
        {
            Id = updatedDebtor.Result.Id
        };
    }
    
    public async Task DeleteAsync(Guid debtorId)
    {
        var debtor = await _unitOfWork.Debtors.GetByIdAsync(debtorId);
        _unitOfWork.Debtors.DeleteAsync(debtor);
    }
}