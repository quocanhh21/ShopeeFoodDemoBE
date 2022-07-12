using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public List<Item> Items { get; set; }
    }
}
