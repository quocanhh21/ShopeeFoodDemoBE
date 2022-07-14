using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Context
{
    public class ShopeeFoodDbContextFactory : IDesignTimeDbContextFactory<ShopeeFoodDbContext>
    {
        public ShopeeFoodDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration= new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("EF/appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ShopeeFoodDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ShopeeFoodDbContext(optionsBuilder.Options);
        }
    }
}
