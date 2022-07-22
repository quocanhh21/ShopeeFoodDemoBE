using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.Services.Models.Requests
{
    public class GetPartnerRequest
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string Keyword { get; set; }

        public int? CategoryId { get; set; }
    }
}
