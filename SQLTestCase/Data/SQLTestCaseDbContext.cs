using Microsoft.EntityFrameworkCore;
using SQLTestCase.Data.Entities;

namespace SQLTestCase.Data
{
    public class SQLTestCaseDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public SQLTestCaseDbContext(DbContextOptions<SQLTestCaseDbContext> options) : base(options)
        {
            _ = Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);

            base.OnModelCreating(modelBuilder);
        }

    }
}