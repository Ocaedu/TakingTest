using Microsoft.EntityFrameworkCore;
using TakingTest.Domain.Entities;

namespace TakingTest.Infra.Contexts
{
    public class SaleContext : DbContext
    {
        private readonly string _connectionString = "Data Source=SQLiteDatbase.db";

        public SaleContext()
        {

        }

        public SaleContext(DbContextOptions<SaleContext> options) : base(options)
        {

        }

        public SaleContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_connectionString);
            }
        }
        public DbSet<Sale> Sales { get; set; }
    }


}
