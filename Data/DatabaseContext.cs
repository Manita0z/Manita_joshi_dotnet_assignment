using Microsoft.EntityFrameworkCore;
using manita_dotnet_assignment.Data;

namespace manita_dotnet_assignment.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
