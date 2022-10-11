using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SmartRental.Infrastructure.Database.Internal
{
    internal class DatabaseContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
