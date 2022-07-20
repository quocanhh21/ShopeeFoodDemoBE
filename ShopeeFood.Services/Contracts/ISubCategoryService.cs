using ShopeeFood.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.Services.Contracts
{
    public interface ISubCategoryService
    {
        Task<List<SubCategoryViewModel>> GetSubCategoryByIdCategory(int idCategory);
    }
}
