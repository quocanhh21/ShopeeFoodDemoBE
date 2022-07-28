using ShopeeFood.DAL.EF.Entities;
using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.Models
{
    public class PartnerViewModel
    {
        public int Id { get; set; }

        public int DistrictForeignKey { get; set; }

        public string District { get; set; }

        public string PartnerName { get; set; }

        public string Address { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        public string Image { get; set; }

        public int Rating { get; set; }

        public int Hot { get; set; }

        public int FastDelivery { get; set; }

        public Status Status { get; set; }

        public List<Menu> Menus { get; set; }

        public List<VoucherPartner> VoucherPartners { get; set; }

        public string VoucherName { get; set; }

        public int TypePartnerForeignKey { get; set; }

        public string TypePartner { get; set; }

    }
}
