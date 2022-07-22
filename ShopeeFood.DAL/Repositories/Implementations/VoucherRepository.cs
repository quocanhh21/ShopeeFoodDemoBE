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
    public class VoucherRepository : IVoucherRepository
    {
        private readonly ShopeeFoodDbContext _context;

        public VoucherRepository(ShopeeFoodDbContext context)
        {
            _context = context;
        }
        public async Task<List<VoucherViewModel>> GetVouchersByPartnerId(int idPartner)
        {
            var query = from vp in _context.VoucherPartners
                        join v in _context.Vouchers
                            on vp.VoucherId equals v.Id
                        where v.Status == EF.Enums.Status.Active &&
                              vp.PartnerId == idPartner
                        select new { v };

            var data = await query.Select(x => new VoucherViewModel()
            {
                Id = x.v.Id,
                VoucherName = x.v.VoucherName,
                Description = x.v.Description,
                Image = x.v.Image,
                PercentDiscount = x.v.PercentDiscount,
                MaxDiscount = x.v.MaxDiscount,
                DiscountMoney = x.v.DiscountMoney,
                MinMoney = x.v.MinMoney,
                Code = x.v.Code,
                FromDate = x.v.FromDate,
                ToDate = x.v.ToDate,
                Stock = x.v.Stock,
                Status = x.v.Status

            }).ToListAsync();

            return data;
        }
    }
}
