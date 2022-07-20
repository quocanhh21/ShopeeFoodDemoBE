using Microsoft.EntityFrameworkCore;
using ShopeeFood.DAL.EF.Context;
using ShopeeFood.DAL.Models;
using ShopeeFood.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.Repositories.Implementations
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ShopeeFoodDbContext _context;

        public SubCategoryRepository(ShopeeFoodDbContext context)
        {
            _context = context;
        }
        public async Task<List<SubCategoryViewModel>> GetSubCategoryByIdCategory(int idCategory)
        {
            var query = from s in _context.SubCategories
                        join c in _context.Categories
                        on s.CategoryForeignKey equals c.Id
                        where c.Status == EF.Enums.Status.Active && s.Status == EF.Enums.Status.Active && c.Id == idCategory
                        select new { s };

            var data = await query.Select(x => new SubCategoryViewModel()
            { 
                Name =x.s.Name,
                SortOrder=x.s.SortOrder
            }).ToListAsync();

            return data;
        }
    }
}
