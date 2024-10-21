using E_Commerce.Application.Abstractions.Repositories;
using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Abstractions.UnitOfWork;
using E_Commerce.Application.Models.DTOs;
using E_Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Services
{
    public class ImageService:IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddImages(List<ImageAddDto> addPostImage)
        {
            List<Image> imgs = addPostImage.Select(i => new Image
            {
                Name = i.Name,
                ProductId = i.ProductId,
                Url = i.Url,

            }).ToList();

            foreach (var img in imgs)
            {
                await _unitOfWork.ImageRepo.AddAsync(img);
                await _unitOfWork.SaveChangesAsync();
            }


        }
    }
}
