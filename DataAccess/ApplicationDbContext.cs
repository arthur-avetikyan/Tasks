using DataAccess.Configuration;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        private readonly DbContextOptions _options;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new StockConfiguration());
            builder.ApplyConfiguration(new PriceConfiguration());
            builder.ApplyConfiguration(new ExchangeRateConfiguration());
        }

        public DbSet<Product> _products { get; set; }
        public DbSet<Stock> _stocks { get; set; }
        public DbSet<Price> _pricess { get; set; }
        public DbSet<ExchangeRate> _exchangeRates { get; set; }
    }
}
