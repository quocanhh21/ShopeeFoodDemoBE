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
                Id = x.p.Id,
                PartnerName = x.p.PartnerName,
                Address = x.p.Address,
                District = x.p.District,
                OpenTime = x.p.OpenTime,
                CloseTime = x.p.CloseTime,
                Image = x.p.Image,
                Rating = x.p.Rating,
                Hot = x.p.Hot,
                FastDelivery = x.p.FastDelivery,
                Menus = x.p.Menus,
                VoucherPartners = x.p.VoucherPartners,
                TypePartner = x.p.TypePartner

            }).ToListAsync();

            return data;
        }

        public async Task<List<PartnerViewModel>> GetBySubCategoryId(int subCategoryId)
        {
            var query = from sc in _context.SubCategories
                        join i in _context.Items
                            on sc.Id equals i.SubCategoryForeignKey
                        join m in _context.Menus
                            on i.MenuForeignKey equals m.Id
                        join p in _context.Partners
                            on m.PartnerForeignKey equals p.Id
                        where sc.Id == subCategoryId
                        select new { p };

            var data = await query.Select(s => new PartnerViewModel()
            {
                Id = s.p.Id,
                Image = s.p.Image,
                PartnerName = s.p.PartnerName,
                Address = s.p.Address,
                District = s.p.District,
                OpenTime = s.p.OpenTime,
                CloseTime = s.p.CloseTime,
                TypePartner = s.p.TypePartner,
            }).Distinct().ToListAsync();

            return data;
        }
    }
}
