using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SmartRental.Infrastructure
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
