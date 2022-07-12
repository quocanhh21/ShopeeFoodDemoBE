using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OrderInList { get; set; }

        public int Amount { get; set; }

        public Status Status { get; set; }

        public List<District> District { get; set; }
    }
}
