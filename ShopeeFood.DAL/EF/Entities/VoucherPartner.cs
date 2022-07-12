using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class VoucherPartner
    {
        public int VoucherId { get; set; }

        public Voucher Voucher { get; set; }

        public int PartnerId { get; set; }

        public Partner Partner { get; set; }

        public Status Status { get; set; }
    }
}
