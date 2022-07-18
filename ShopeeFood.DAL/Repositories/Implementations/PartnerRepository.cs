using Microsoft.EntityFrameworkCore;
using ShopeeFood.DAL.EF.Context;
using ShopeeFood.DAL.Models;
using ShopeeFood.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.Repositories.Implementations
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly ShopeeFoodDbContext _context;

        public PartnerRepository(ShopeeFoodDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get parter by caterory ID 
        /// </summary>
        /// <returns>List partner</returns>
        public async Task<List<PartnerViewModel>> GetAllByCategoryId()
        {
            var query = from p in _context.Partners
                        
                        select new { p };
            var data = await query.Select(x => new PartnerViewModel()
            {
                Id=x.p.Id,
                PartnerName=x.p.PartnerName
            }).ToListAsync();

            return data;
        }

        public Task<List<PartnerViewModel>> GetBySubCategoryId()
        {
            throw new NotImplementedException();
        }
    }
}
