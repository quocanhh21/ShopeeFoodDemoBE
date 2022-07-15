using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class OptionType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public StatusOptionType IsRequired { get; set; }

        public Status Status { get; set; }

        public List<OptionType_OptionItem> OptionType_OptionItem { get; set; }

        public List<OptionType_Item> OptionType_Item { get; set; }
    }
}
