using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class OptionItem
    {
        public int Id { get; set; }

        public string OptionName { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public List<OptionType_OptionItem> OptionType_OptionItem { get; set; }
    }
}
