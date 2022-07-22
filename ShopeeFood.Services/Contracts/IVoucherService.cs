using ShopeeFood.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.Services.Contracts
{
    public interface IVoucherService
    {
        Task<List<VoucherViewModel>> GetVouchersByPartnerId(int idPartner);
    }
}
