using Microsoft.EntityFrameworkCore;
using Store.Entities.Models;

namespace Store.DAL.Infrastructure
{
    public partial class MarketDbContext : DbContext
    {
        public MarketDbContext()
        {
        }

        public MarketDbContext(DbContextOptions<MarketDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExchangeRate> ExchangeRate { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRate>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.DestinationCurrency).IsUnicode(false);

                entity.Property(e => e.SourceCurrency).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.StockId)
                    .HasName("UQ__Product__2C83A9C3F7EAEAB8")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Currency)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Amd')");

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__412EB0B6");

                entity.HasOne(d => d.Stock)
                    .WithOne(p => p.Product)
                    .HasForeignKey<Product>(d => d.StockId)
                    .HasConstraintName("FK__Product__StockId__2B3F6F97");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__ProductC__8517B2E0BE4D5141")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryName).IsUnicode(false);

                entity.Property(e => e.CategoryTag).IsUnicode(false);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.InStock).HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
