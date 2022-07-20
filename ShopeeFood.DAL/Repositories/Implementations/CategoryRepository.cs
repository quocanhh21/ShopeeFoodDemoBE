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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopeeFoodDbContext _context;

        public CategoryRepository(ShopeeFoodDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryViewModel>> GetAllCategory()
        {
            var query = from c in _context.Categories
                        where c.Status == EF.Enums.Status.Active
                        select new { c };

            var data = await query.Select(x => new CategoryViewModel()
            { 
                SortOrder= x.c.SortOrder,
                CateName = x.c.CateName 
            }
            ).ToListAsync();

            return data;
        }
    }
}
