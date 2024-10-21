using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(p => p.Price)
                   .IsRequired();

            builder.HasMany(p => p.Images)
                   .WithOne(p => p.Product)
                   .HasForeignKey(p => p.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
            new Product
            {
                Id = Guid.Parse("a8a72ef4-1b45-4b59-bc0d-3a0cb7a0f74f"),
                Name = "Product 1",
                Description = "Description for Product 1",
                Price = 19.99
            },
            new Product
            {
                Id = Guid.Parse("c2c89d35-72a7-4cc8-bb77-7f7454d1d2de"),
                Name = "Product 2",
                Description = "Description for Product 2",
                Price = 29.99
            },
            new Product
            {
                Id = Guid.Parse("e4b56b1a-6372-4e5b-9f61-03ee2b5e6b64"),
                Name = "Product 3",
                Description = "Description for Product 3",
                Price = 39.99
            },
            new Product
            {
                Id = Guid.Parse("e4b56b1a-6372-4e5b-9f61-03ee2b5e5a64"),
                Name = "Product 4",
                Description = "Description for Product 4",
                Price = 39.99
            }
          );
        }
    }
}
