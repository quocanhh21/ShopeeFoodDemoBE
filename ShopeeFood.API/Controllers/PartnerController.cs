using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFood.DAL.Models;
using ShopeeFood.DAL.Repositories.Contracts;
using ShopeeFood.Services.Contracts;
using ShopeeFood.Services.Implementations;


namespace ShopeeFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaging()
        {
            var partners = await _partnerService.GetAllByCategoryId();
            return Ok(partners);
        }

        [HttpGet("{subCategoryId}")]
        public async Task<IActionResult> GetPartnersBySubCategoryId(int subCategoryId)
        {
            var partners = await _partnerService.GetBySubCategoryId(subCategoryId);
            return Ok(partners);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetPartnerRequest request)
        {
            var products = await _partnerService.GetAllPartnerPromotePaging(request);
            return Ok(products);
        }
    }
}
