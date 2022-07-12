using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public Menu Menu { get; set; }

        public SubCategory SubCategory { get; set; }

        public string NameItem { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public int ViewCount { get; set; }

        public int Stock { get; set; }

        public DateTime DateCreated { get; set; }

        public Status Status { get; set; }

        public List<OptionType_Item> OptionTye_Item { get; set; }
    }
}
