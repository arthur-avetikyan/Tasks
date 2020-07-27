﻿using Microsoft.EntityFrameworkCore;
using Store.DAL.Configuration;
using Store.Entities;

namespace Store.DAL
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

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Price> Pricess { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
