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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(i => i.Id);


            var carts = new List<Cart> {

            new Cart
            {
                Id = Guid.Parse("ea83a2e4-7efb-4078-87d0-1abd38e00198"),
                CreateTime = DateTime.Now,
                IsActive = false,
                TotalPrice = 0,
            }
            };
            builder.HasData(carts);
        }

    }
}
