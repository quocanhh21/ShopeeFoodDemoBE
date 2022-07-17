using ShopeeFood.DAL.EF.Context;
using ShopeeFood.DAL.Models;
using ShopeeFood.Services.Contracts;
using ShopeeFood.Services.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.Services.Implementations
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerService _partnerRepository;

        public PartnerService(IPartnerService partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }
        public async Task<List<PartnerViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
