using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Data.EntityConfiguration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                   .IsRequired();

            builder.Property(i => i.Size)
                   .IsRequired();

            builder.Property(i => i.Url)
                   .IsRequired();
            var images = new List<Image> {
            new Image
            {
                 Id = Guid.Parse("FE895FEB-758F-435C-F93C-08DCF4E8B1BC"),
                 CreateTime = DateTime.Now,
                 Name = "f24f42ee-85ac-4720-b4f2-ce58a3b1a404.jpeg",
                 Url="https://localhost:7244/Images/f24f42ee-85ac-4720-b4f2-ce58a3b1a404.jpeg",
                 ProductId = Guid.Parse("2CC1CA42-7F05-48E9-B223-886C5C98A4AF")
             },

            new Image
            {
                 Id = Guid.Parse("5B3E4856-ACEE-452F-F945-08DCF4E8B1BC"),
                 CreateTime = DateTime.Now,
                 Name = "d6caca02-fd7a-4cf9-a04b-5eac3c91b57b.jpg",
                 Url="https://localhost:7244/Images/d6caca02-fd7a-4cf9-a04b-5eac3c91b57b.jpg",
                 ProductId = Guid.Parse("C8FAAAE7-FEE5-450C-AC98-0BAAA046077D")
             },

            new Image
            {
                 Id = Guid.Parse("D3033060-43B4-44E9-F946-08DCF4E8B1BC"),
                 CreateTime = DateTime.Now,
                 Name = "5f7f0f1a-ab8d-4cbb-8aca-8d90a2e7ed0b.jpg",
                 Url="https://localhost:7244/Images/5f7f0f1a-ab8d-4cbb-8aca-8d90a2e7ed0b.jpg",
                 ProductId = Guid.Parse("C8FAAAE7-FEE5-450C-AC98-0BAAA046077D")
             },
            new Image
            {
                 Id = Guid.Parse("BD522D65-99D7-44F0-F947-08DCF4E8B1BC"),
                 CreateTime = DateTime.Now,
                 Name = "a7b4b27c-1100-42c5-9b50-c34782ffd7eb.jpeg",
                 Url="https://localhost:7244/Images/a7b4b27c-1100-42c5-9b50-c34782ffd7eb.jpeg",
                 ProductId = Guid.Parse("C8FAAAE7-FEE5-450C-AC98-0BAAA046077D")
             },
            new Image
            {
                 Id = Guid.Parse("9C8DC570-A351-4AC7-8C14-08DCF4EA92AE"),
                 CreateTime = DateTime.Now,
                 Name = "8b38c948-cbb4-48e4-b246-3c6bf8af1f4e.jpeg",
                 Url="https://localhost:7244/Images/8b38c948-cbb4-48e4-b246-3c6bf8af1f4e.jpeg",
                 ProductId = Guid.Parse("E4B56B1A-6372-4E5B-9F61-03EE2B5E6B64")
             },
            new Image
            {
                 Id = Guid.Parse("003096BD-53DE-4280-8C15-08DCF4EA92AE"),
                 CreateTime = DateTime.Now,
                 Name = "54f58d46-820b-4146-b400-31d8f0bb2b40.jpg",
                 Url="https://localhost:7244/Images/54f58d46-820b-4146-b400-31d8f0bb2b40.jpg",
                 ProductId = Guid.Parse("E4B56B1A-6372-4E5B-9F61-03EE2B5E6B64")
             },
            new Image
            {
                 Id = Guid.Parse("9F96A597-6C46-4776-8C16-08DCF4EA92AE"),
                 CreateTime = DateTime.Now,
                 Name = "d7ceebbb-4e5b-4ced-94a4-1db17838a76c.jpg",
                 Url="https://localhost:7244/Images/d7ceebbb-4e5b-4ced-94a4-1db17838a76c.jpg",
                 ProductId = Guid.Parse("E4B56B1A-6372-4E5B-9F61-03EE2B5E6B64")
             },
            new Image
            {
                 Id = Guid.Parse("2E4D74A0-DB8E-4683-8C17-08DCF4EA92AE"),
                 CreateTime = DateTime.Now,
                 Name = "e427320d-aaa9-43a7-9890-9de5da5b9075.png",
                 Url="https://localhost:7244/Images/e427320d-aaa9-43a7-9890-9de5da5b9075.png",
                 ProductId = Guid.Parse("0D7957D2-2CA7-43EB-B9E0-6E300DA1A6B4")
             },

            new Image
            {
                 Id = Guid.Parse("AD4E838D-5EEB-4D51-8C18-08DCF4EA92AE"),
                 CreateTime = DateTime.Now,
                 Name = "0f149b06-741f-4ccc-aa64-65c241a2d9cb.jpeg",
                 Url="https://localhost:7244/Images/0f149b06-741f-4ccc-aa64-65c241a2d9cb.jpeg",
                 ProductId = Guid.Parse("0D7957D2-2CA7-43EB-B9E0-6E300DA1A6B4")
             },
            new Image
            {
                 Id = Guid.Parse("7586FA36-5E18-451A-8C19-08DCF4EA92AE"),
                 CreateTime = DateTime.Now,
                 Name = "28dce458-85d8-4fc9-a4b0-eb6ab08989cf.jpg",
                 Url="https://localhost:7244/Images/28dce458-85d8-4fc9-a4b0-eb6ab08989cf.jpg",
                 ProductId = Guid.Parse("0D7957D2-2CA7-43EB-B9E0-6E300DA1A6B4")
             },
            new Image
            {
                 Id = Guid.Parse("D2E23CF5-C9BD-4CD1-8C1A-08DCF4EA92AE"),
                 CreateTime = DateTime.Now,
                 Name = "3ac6aab1-980a-4b06-9166-82c8173d9cb1.jpeg",
                 Url="https://localhost:7244/Images/3ac6aab1-980a-4b06-9166-82c8173d9cb1.jpeg",
                 ProductId = Guid.Parse("A4C61A6B-42AB-47B9-BAF4-8B5CA7F8A5E4")
             },
            new Image
            {
                 Id = Guid.Parse("70AB1FAE-ADC1-443F-8C1B-08DCF4EA92AE"),
                 CreateTime = DateTime.Now,
                 Name = "38f901ac-47e0-486c-8af0-525f7ce12f6f.png",
                 Url="https://localhost:7244/Images/38f901ac-47e0-486c-8af0-525f7ce12f6f.png",
                 ProductId = Guid.Parse("A4C61A6B-42AB-47B9-BAF4-8B5CA7F8A5E4")
             },
            new Image
            {
                 Id = Guid.Parse("3D490C78-B0AF-45DE-8C1C-08DCF4EA92AE"),
                 CreateTime = DateTime.Now,
                 Name = "e21efe8e-4890-4582-9dc7-0efd8f1d94af.jpeg",
                 Url="https://localhost:7244/Images/e21efe8e-4890-4582-9dc7-0efd8f1d94af.jpeg",
                 ProductId = Guid.Parse("A4C61A6B-42AB-47B9-BAF4-8B5CA7F8A5E4")
             },
            };
            builder.HasData(images);
        }
    }
}
