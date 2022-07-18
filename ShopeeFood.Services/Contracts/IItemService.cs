using ShopeeFood.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.Services.Contracts
{
    public interface IItemService
    {
        IEnumerable<Item> GetAll();

        IEnumerable<Item> GetAll(string keyWord);

    }
}
