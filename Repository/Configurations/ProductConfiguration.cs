using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();

            builder.Property(x => x.IsOfferable).IsRequired();
            //builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.Photo).IsRequired();
            builder.Property(x => x.IsSold).IsRequired();
            ;
            // builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(10,2)");

  


            //builder.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId);
            //builder.HasOne(x => x.Color).WithMany(x => x.Products).HasForeignKey(x => x.ColorId);


        }
    }
}

