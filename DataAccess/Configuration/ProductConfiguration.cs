using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(k => k.Stock).WithOne().IsRequired(true).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(k => k.Price).WithOne().IsRequired(true).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
