using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        DbSet<Operation> Operations { get; set; }
        DbSet<OperationType> OperationTypes { get; set; }

    }
}
