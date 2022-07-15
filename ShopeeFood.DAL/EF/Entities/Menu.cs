using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class Menu
    {
        public int Id { get; set; }
            
        public string Name { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public int PartnerForeignKey { get; set; }

        public Partner Partner { get; set; }

        public List<Item> Items { get; set; }
    }
}
