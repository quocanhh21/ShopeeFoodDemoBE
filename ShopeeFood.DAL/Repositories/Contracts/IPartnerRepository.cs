using ShopeeFood.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.Repositories.Contracts
{
    public interface IPartnerRepository
    {
        Task<List<PartnerViewModel>> GetAllByCategoryId();

        Task<List<PartnerViewModel>> GetBySubCategoryId(int subCategoryId);

    }
}
