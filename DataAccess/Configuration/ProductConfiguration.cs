using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Entities;

namespace Store.DAL.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(k => k.Id);
            builder.HasOne(p=>p.Stock).WithOne(s=>s.Product).HasForeignKey<Stock>(f=>f.ProductId);
            builder.HasOne(p=>p.Price).WithOne(s=>s.Product).HasForeignKey<Price>(f=>f.ProductId);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
