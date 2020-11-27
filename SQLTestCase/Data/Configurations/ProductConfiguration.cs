using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SQLTestCase.Data.Entities;

namespace SQLTestCase.Data.Configurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.Property(p => p.Price).HasColumnName("Price").HasPrecision(10,2).IsRequired();
            builder.Property(p => p.Category).HasColumnName("Category").IsRequired();
        }
    }
}