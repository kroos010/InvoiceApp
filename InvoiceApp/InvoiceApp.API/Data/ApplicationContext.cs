using InvoiceApp.API.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApp.API.Data;

public class ApplicationContext : IdentityDbContext<Account>
{
    // public RepositoryContext(DbContextOptions options)
    //     : base(options)
    // {
    // }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        // modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }

    // public DbSet<Company>? Companies { get; set; }
    // public DbSet<Employee>? Employees { get; set; }
}