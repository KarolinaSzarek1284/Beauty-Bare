using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Contraindications).HasMaxLength(150);
            builder.Property(p => p.Apllying).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Capacity).IsRequired();
            builder.Property(p => p.IsVegan).IsRequired();
            builder.Property(p => p.InUse).IsRequired();
            builder.Property(p => p.Country).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();

            builder.HasOne(b => b.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(c => c.ProductCategory).WithMany()
                .HasForeignKey(c => c.ProductCategoryId);
            builder.HasOne(s => s.ProductSubcategory).WithMany()
                .HasForeignKey(s => s.ProductSubcategoryId);
        }
    }
}
