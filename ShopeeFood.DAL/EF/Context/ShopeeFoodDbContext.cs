using Microsoft.EntityFrameworkCore;
using ShopeeFood.DAL.EF.Configurations;
using ShopeeFood.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Context
{
    public class ShopeeFoodDbContext: DbContext
    {
        public ShopeeFoodDbContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppConfig> AppConfigs { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<OptionItem> OptionItems { get; set; }

        public DbSet<OptionType> OptionTypes { get; set; }

        public DbSet<OptionType_Item> OptionType_Item { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Partner> Partners { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<TypePartner> TypePartners { get; set; }

        public DbSet<Voucher> Vouchers { get; set; }

        public DbSet<VoucherPartner> VoucherPartners { get; set; }

    }
}
