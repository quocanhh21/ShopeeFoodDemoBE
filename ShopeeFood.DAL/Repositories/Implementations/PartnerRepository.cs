using Microsoft.EntityFrameworkCore;
using ShopeeFood.DAL.EF.Context;
using ShopeeFood.DAL.Models;
using ShopeeFood.DAL.Repositories.Contracts;

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
        public async Task<PageResult<PartnerViewModel>> GetAllPartnerPaging(GetPartnerRequest request)
        {
            //----------Case 1: Group by------------------------
            var query = from d in _context.Districts
                        join p in _context.Partners
                            on d.Id equals p.DistrictForeignKey into d_p
                        from p in d_p.DefaultIfEmpty()
                        join m in _context.Menus
                            on p.Id equals m.PartnerForeignKey into p_m
                        from m in p_m.DefaultIfEmpty()
                        join i in _context.Items
                             on m.Id equals i.MenuForeignKey into m_i
                        from i in m_i.DefaultIfEmpty()
                        join sc in _context.SubCategories
                             on i.SubCategoryForeignKey equals sc.Id into i_sc
                        from sc in i_sc.DefaultIfEmpty()
                        join c in _context.Categories
                             on sc.CategoryForeignKey equals c.Id into sc_c
                        from c in sc_c.DefaultIfEmpty()
                        where p.Status == EF.Enums.Status.Active
                        select new { d,p,m,i,c,sc};

            // filter search keyword
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.p.PartnerName.ToLower().Contains(request.Keyword.ToLower()));
            }

            // filter by category id 
            if (request.CategoryId > 0)
            {
                query = query.Where(x => x.c.Id == request.CategoryId);
            }

            //filter by district id 
            if (request.DistrictId != null && request.DistrictId.Any() )
            {
                query = query.Where(x => request.DistrictId.Any(t => t == x.d.Id));
            }

            //filter by district id 
            if (request.IsPromote)
            {
                var voucher = query.Select(x=>x.p.VoucherPartners).FirstOrDefault();
            }

            //group by partner has item
            var groupPartner =await query.GroupBy(gr => new
            {
                gr.p.Id,
                gr.p.PartnerName,
                gr.p.Image,
                gr.p.Address,
                nameDistrict = gr.p.District.Name,
                gr.p.OpenTime,
                gr.p.CloseTime,
                nameType = gr.p.TypePartner.Name,
                voucherName=gr.p.VoucherPartners.Select(x=>x.Voucher.VoucherName).FirstOrDefault()
                
            }).Select(s => new PartnerViewModel()
            {
                Id = s.Key.Id,
                PartnerName = s.Key.PartnerName,
                Image = s.Key.Image,
                Address = s.Key.Address,
                District = s.Key.nameDistrict,
                OpenTime = s.Key.OpenTime,
                CloseTime = s.Key.CloseTime,
                TypePartner = s.Key.nameType,
                VoucherName= (s.Key.voucherName != null) ? s.Key.voucherName : s.Key.nameType

            }).ToListAsync();

            //paging

            int totalRow =  groupPartner.GroupBy(gr => gr.Id).Count();

            var data = groupPartner.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).ToList();

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

            return data;
        }
    }
}
