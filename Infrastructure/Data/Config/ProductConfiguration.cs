using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(property => property.Name).IsRequired().HasMaxLength(100);
            builder.Property(property => property.Description).IsRequired().HasMaxLength(180);
            builder.Property(property => property.Price).HasColumnType("decimal(18,2)");
            builder.Property(property => property.PictureUrl).IsRequired();
            // The code below is for completeness sake, EF already does this when convention naming is used
            // builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
        }
    }
}