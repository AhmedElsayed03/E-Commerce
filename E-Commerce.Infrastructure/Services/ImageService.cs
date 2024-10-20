using E_Commerce.Application.Abstractions.Repositories;
using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Abstractions.UnitOfWork;
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
    }
}
