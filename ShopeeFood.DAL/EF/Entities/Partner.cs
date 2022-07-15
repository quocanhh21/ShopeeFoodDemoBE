using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class Partner
    {
        public int Id { get; set; }

        public int DistrictForeignKey { get; set; }

        public District District { get; set; }

        public string PartnerName { get; set; }

        public string Address { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        public int Rating { get; set; }

        public int Hot { get; set; }

        public int FastDelivery { get; set; }

        public Status Status { get; set; }

        public List<Menu> Menus { get; set; }

        public List<VoucherPartner> VoucherPartners { get; set; }

        public List<Order> Orders { get; set; }

        public int TypePartnerForeignKey { get; set; }

        public TypePartner TypePartner { get; set; }
    }
}
