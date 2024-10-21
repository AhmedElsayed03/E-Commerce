using E_Commerce.Application.Abstractions.Services;
using E_Commerce.Application.Models.DTOs;
using E_Commerce.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Route("Add-Category")]
        public ActionResult AddCategory(CategoryAddDto newCategory)
        {
            _categoryService.AddCategory(newCategory);
            return Ok("Category Added!");
        }

    }
}
