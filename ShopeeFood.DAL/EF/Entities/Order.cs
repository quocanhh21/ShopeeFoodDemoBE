using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public decimal TotalMoney { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipEmail { get; set; }

        public string ShipPhone { get; set; }

        public OrderStatus OrderStatus { get; set; }

        //public Customer Customer { get; set; }

        public Partner Partner { get; set; }

        public Voucher Voucher { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
    }
}
