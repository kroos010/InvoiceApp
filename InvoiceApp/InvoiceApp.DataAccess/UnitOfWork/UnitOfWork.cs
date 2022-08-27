using InvoiceApp.DataAccess.Persistence;
using InvoiceApp.DataAccess.Repositories.Contracts;
using InvoiceApp.DataAccess.UnitOfWork.Contracts;

namespace InvoiceApp.DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    // public IDeveloperRepository Developers { get; private set; }
    // public IProjectRepository Projects { get; private set; }
    public IDebtorRepository Debtors { get; private set; }

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
        // Debtors = new DebtorRepository(_context);
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}