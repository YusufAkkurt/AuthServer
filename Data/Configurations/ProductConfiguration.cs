using AuthServer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServer.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.UderId).IsRequired();
            builder.Property(prop => prop.Name).IsRequired().HasMaxLength(200);
            builder.Property(prop => prop.Stock).IsRequired();
            builder.Property(prop => prop.Price).HasColumnType("decimal(18,2)");
        }
    }
}
