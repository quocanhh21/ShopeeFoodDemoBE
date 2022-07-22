using ShopeeFood.DAL.Models;
using ShopeeFood.DAL.Repositories.Contracts;
using ShopeeFood.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.Services.Implementations
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _voucherRepository;

        public VoucherService(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }
        public async Task<List<VoucherViewModel>> GetVouchersByPartnerId(int idPartner)
        {
            return await _voucherRepository.GetVouchersByPartnerId(idPartner);
        }
    }
}
