using InvoiceApp.Core.Entities;
using InvoiceApp.DataAccess.Persistence;
using InvoiceApp.DataAccess.Repositories.Contracts;

namespace InvoiceApp.DataAccess.Repositories;

public class DebtorRepository : GenericRepository<Debtor>, IDebtorRepository
{
    public DebtorRepository(ApplicationContext context) : base(context)
    {

    }
}