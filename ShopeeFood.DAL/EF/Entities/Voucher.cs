﻿using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class Voucher
    {
        public int Id { get; set; }

        public Category Category { get; set; }

        public string VoucherName { get; set; }

        public string Description { get; set; }

        public double? PercentDiscount { get; set; }

        public double? MaxDiscount { get; set; }

        public double? DiscountMoney { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Stock { get; set; }

        public Status Status { get; set; }

        public List<VoucherPartner> VoucherPartners { get; set; }

        public List<Order> Orders { get; set; }
    }
}
