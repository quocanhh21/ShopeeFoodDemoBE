using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.Models
{
    public class GetPartnerRequest
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string? Keyword { get; set; }

        public int CategoryId { get; set; }

        public IList<int>? DistrictId { get; set; }

        public IList<int>? SubCategoyIds { get; set; }

        public bool IsPromote { get; set; } = false;
    }
}
