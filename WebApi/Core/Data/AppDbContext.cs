using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        DbSet<IncomeOperation> IncomeOperations { get; set; }
        DbSet<ExpenseOperation> ExpenseOperations { get; set; }

    }
}
