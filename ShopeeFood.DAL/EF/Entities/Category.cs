using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public int SortOrder { get; set; }

        public string CateName { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public List<SubCategory> SubCategories { get; set; }

        public List<Voucher> Vouchers { get; set; }
    }
}
