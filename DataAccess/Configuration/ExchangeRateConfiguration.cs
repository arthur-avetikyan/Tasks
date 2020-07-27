using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
