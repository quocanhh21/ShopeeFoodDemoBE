using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFood.Services.Contracts;

namespace ShopeeFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetSubCategoryByIdCategory(int categoryId)
        {
            var subCategories = await _subCategoryService.GetSubCategoryByIdCategory(categoryId);

            if (subCategories == null)
            {
                return BadRequest("Cannot find");
            }
            return Ok(subCategories);
        }
    }
}
