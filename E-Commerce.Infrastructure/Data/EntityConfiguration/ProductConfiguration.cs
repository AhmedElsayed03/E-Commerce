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

            var products = new List<Product> {
             new Product
            {
                Id = Guid.Parse("2cc1ca42-7f05-48e9-b223-886c5c98a4af"),
                Name = "IPhone 15 Pro",
                Description = "Titanum - 1TB",
                Price = 59.99,
                CategoryId = Guid.Parse("bdafc3c9-abe6-4ac5-bdb6-8361524ff999")
            },
            new Product
            {
                Id = Guid.Parse("a4c61a6b-42ab-47b9-baf4-8b5ca7f8a5e4"),
                Name = "IPhone X",
                Description = "White - 64GB",
                Price = 15.99,
                CategoryId = Guid.Parse("bdafc3c9-abe6-4ac5-bdb6-8361524ff999")
            },
            new Product
            {
                Id = Guid.Parse("c8faaae7-fee5-450c-ac98-0baaa046077d"),
                Name = "IPhone 13",
                Description = "Moonlight - 128GB",
                Price = 29.99,
                CategoryId = Guid.Parse("bdafc3c9-abe6-4ac5-bdb6-8361524ff999")
            },
            new Product
            {
                Id = Guid.Parse("e4b56b1a-6372-4e5b-9f61-03ee2b5e6b64"),
                Name = "MacBook Pro 16-inch",
                Description = "256GB SSD Storage / 8-Core CPU 8-Core GPU 8GB Unified Memory",
                Price = 1500.99,
                CategoryId = Guid.Parse("f5a4eb59-26b3-4784-b427-65b5f7f57052")
            },
            new Product
            {
                Id = Guid.Parse("0d7957d2-2ca7-43eb-b9e0-6e300da1a6b4"),
                Name = "MacBook Air 13-inch",
                Description = "M3 Max / 1TB / 16-core CPU 40-core GPU 48GB Unified Memory",
                Price = 1350.99,
                CategoryId = Guid.Parse("f5a4eb59-26b3-4784-b427-65b5f7f57052")
            }
            };
            builder.HasData(products);
        }
    }
}
