using ShopeeFood.DAL.EF.Entities;
using ShopeeFood.DAL.Models;
using ShopeeFood.Services.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.Services.Contracts
{
    public interface IPartnerService
    {
        Task<List<PartnerViewModel>> GetAll();

        //PagedViewModel<PartnerViewModel> GetAllByCategoryId(int catagoryId, int pageIndex, int pageSized);

        //IEnumerable<Partner> GetListPartnerBySubCategoryIdPaging(int subCategory,int page, int pageSize, string sort,out int totalRow);
    }
}
