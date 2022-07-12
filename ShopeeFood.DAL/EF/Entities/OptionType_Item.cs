using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class OptionType_Item
    {
        public int OptionTypeId { get; set; }

        public OptionType OptionType { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public Status Status { get; set; }
    }
}
