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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired();

            builder.HasMany(p => p.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull);

            var categories = new List<Category> {

            new Category
            {
                Id = Guid.Parse("bdafc3c9-abe6-4ac5-bdb6-8361524ff999"),
                Name = "Mobile Phones",
                CreateTime = DateTime.Now
            },
            new Category
            {
                Id = Guid.Parse("f5a4eb59-26b3-4784-b427-65b5f7f57052"),
                Name = "Laptops",
                CreateTime = DateTime.Now
            }
            };
            builder.HasData(categories);
        }
    }
}