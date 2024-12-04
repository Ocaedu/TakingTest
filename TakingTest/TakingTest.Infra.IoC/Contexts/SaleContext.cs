
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
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Branch> Branchs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Service Provider
            //modelBuilder.ApplyConfiguration(new ClientConfiguration());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SalesProduct>().HasKey(f => new { f.ProductId, f.SaleId });

            modelBuilder.Entity<Sale>()
                .HasMany(e => e.SaleProducts)
                .WithOne(e => e.Sale)
                .HasForeignKey(e => e.SaleId)
                .HasPrincipalKey(e => e.Id);

        }

    }


}
