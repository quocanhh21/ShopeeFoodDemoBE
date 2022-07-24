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
                District = x.p.District.Name,
                OpenTime = x.p.OpenTime,
                CloseTime = x.p.CloseTime,
                Image = x.p.Image,
                Rating = x.p.Rating,
                Hot = x.p.Hot,
                FastDelivery = x.p.FastDelivery,
                Menus = x.p.Menus,
                VoucherPartners = x.p.VoucherPartners,
                TypePartner = x.p.TypePartner.Name

            }).ToListAsync();

            return data;
        }

        /// <summary>
        /// Get partner have any promote
        /// </summary>
        /// <param name="request"></param> 
        /// <returns></returns>
        public async Task<PageResult<PartnerViewModel>> GetAllPartnerPromotePaging(GetPartnerRequest request)
        {
            var query = from p in _context.Partners
                        join vp in _context.VoucherPartners
                            on p.Id equals vp.PartnerId
                        join v in _context.Vouchers
                            on vp.VoucherId equals v.Id
                        join c in _context.Categories
                            on v.CategoryForeignKey equals c.Id
                        where p.Status == EF.Enums.Status.Active && c.Id == request.CategoryId
                        select new { p };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.PartnerName.Contains(request.Keyword));
            }

            //paging

            int totalRow = await query.GroupBy(gr => gr.p.Id).CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .GroupBy(gr => new
                {
                    gr.p.Id,
                    gr.p.PartnerName,
                    gr.p.Image,
                    gr.p.Address,
                    nameDistrict = gr.p.District.Name,
                    gr.p.OpenTime,
                    gr.p.CloseTime,
                    nameType = gr.p.TypePartner.Name
                }).Select(s => new PartnerViewModel()
                {
                    Id = s.Key.Id,
                    PartnerName = s.Key.PartnerName,
                    Image = s.Key.Image,
                    Address = s.Key.Address,
                    District = s.Key.nameDistrict,
                    OpenTime = s.Key.OpenTime,
                    CloseTime = s.Key.CloseTime,
                    TypePartner = s.Key.nameDistrict

                }).ToListAsync();

            //Select and projection
            var pagedResult = new PageResult<PartnerViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };

            return pagedResult;
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

            var data = await query.GroupBy(gr => new 
            { 
                gr.p.Id, 
                gr.p.PartnerName,
                gr.p.Image,
                gr.p.Address,
                nameDistrict = gr.p.District.Name,
                gr.p.OpenTime,
                gr.p.CloseTime,
                nameType= gr.p.TypePartner.Name
            }).Select(s => new PartnerViewModel()
            {
                Id = s.Key.Id,
                PartnerName = s.Key.PartnerName,
                Image = s.Key.Image,
                Address = s.Key.Address,
                District = s.Key.nameDistrict,
                OpenTime = s.Key.OpenTime,
                CloseTime = s.Key.CloseTime,
                TypePartner=s.Key.nameDistrict

            }).ToListAsync();

            return data;
        }
    }
}
