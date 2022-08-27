using InvoiceApp.DataAccess.Repositories.Contracts;

namespace InvoiceApp.DataAccess.UnitOfWork.Contracts;

public interface IUnitOfWork : IDisposable
{
    IDebtorRepository Debtors{ get; }
    int Complete();
}