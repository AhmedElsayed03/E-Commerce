﻿using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Models.DTOs;
using E_Commerce.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        [Route("PostPictures")]
        public ActionResult<List<ImageAddDto>> PostPictures([FromForm] List<IFormFile> ImageFile, Guid productId)
        {

            var listOfImgs = new List<ImageAddDto>();

            foreach (var img in ImageFile)
            {

                #region Extention Checking
                var extension = Path.GetExtension(img.FileName);
                var extensionList = new string[]
                {
                ".png",
                ".jpg",
                ".jpeg"
                };

                bool isExtensionAllowed = extensionList.Contains(extension,
                    StringComparer.InvariantCultureIgnoreCase);
                if (!isExtensionAllowed)
                {
                    return BadRequest("Format not allowed");
                }
                #endregion

                #region Length Checking

                bool isSizeAllowed = img.Length is > 0 and < 5_000_000; //Picture Size (Minimum: >0 and Max: 5MB)

                if (!isSizeAllowed)
                {
                    return BadRequest("Size is Larger than allowed size");
                }
                #endregion

                #region Storing Image
                var generatedPictureName = $"{Guid.NewGuid()}{extension}";
                var savedPicturesPath = Environment.CurrentDirectory + "/Images/Posts/" + generatedPictureName;
                using var stream = new FileStream(savedPicturesPath, FileMode.Create);
                img.CopyTo(stream);
                #endregion

                #region URL Generating
                var url = $"{Request.Scheme}://{Request.Host}/Images/{generatedPictureName}";
                #endregion

                var newImg = new ImageAddDto
                {
                    Name = generatedPictureName,
                    ProductId = productId,
                    Url = url
                };

                listOfImgs.Add(newImg);
            }
            _imageService.AddImages(listOfImgs);
            return Ok(listOfImgs);
        }
    }
}
