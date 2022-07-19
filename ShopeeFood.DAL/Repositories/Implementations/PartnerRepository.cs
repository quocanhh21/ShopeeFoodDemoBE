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
                        where p.Status == EF.Enums.Status.Active
                        select new { p };
            var data = await query.Select(x => new PartnerViewModel()
            {
                Id=x.p.Id,
                PartnerName=x.p.PartnerName,
                Address= x.p.Address,
                District=x.p.District,
                OpenTime=x.p.OpenTime,  
                CloseTime=x.p.CloseTime,    
                Image=x.p.Image,
                Rating=x.p.Rating,
                Hot=x.p.Hot,
                FastDelivery=x.p.FastDelivery,
                Menus=x.p.Menus,
                VoucherPartners=x.p.VoucherPartners,
                TypePartner=x.p.TypePartner

            }).ToListAsync();

            return data;
        }

        public Task<List<PartnerViewModel>> GetBySubCategoryId(int subCategoryId)
        {
            //var query= from tp in _context.TypePartners
            //           join p in _context.Partners on tp.Id equals p.TypePartnerForeignKey
            //           where

            throw new NotImplementedException();
        }
    }
}
