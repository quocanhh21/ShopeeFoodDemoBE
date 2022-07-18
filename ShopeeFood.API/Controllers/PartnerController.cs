﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
