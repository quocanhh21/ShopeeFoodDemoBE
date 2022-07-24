using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFood.Services.Contracts;

namespace ShopeeFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;

        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpGet("{idPartner}")]
        public async Task<IActionResult> GetVouchersByPartnerId(int idPartner)
        {
            var vouchers = await _voucherService.GetVouchersByPartnerId(idPartner);
            return Ok(vouchers);
        }

        [HttpGet("idCategory")]
        public async Task<IActionResult> GetAllVoucherByCategoryId(int idCategory)
        {
            var vouchers = await _voucherService.GetAllVoucherByCategoryId(idCategory);
            return Ok(vouchers);
        }
    }
}
