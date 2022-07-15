using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class ShopeeFoodDbContext: IdentityDbContext<Customer, AppRole,Guid>
    {
        public ShopeeFoodDbContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new OptionType_OptionItemConfiguration());
            modelBuilder.ApplyConfiguration(new OptionItemConfiguration());
            modelBuilder.ApplyConfiguration(new OptionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OptionTypes_ItemsConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PartnerConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TypePartnerConfiguration());
            modelBuilder.ApplyConfiguration(new VoucherConfiguration());
            modelBuilder.ApplyConfiguration(new VoucherPartnerConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("CustomerClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("CustomerRoles")
                .HasKey(x=> new { x.UserId, x.RoleId});
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("CustomerLogins")
                .HasKey(x=>x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("CustomerRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("CustomerUserTokens")
                .HasKey(x=>x.UserId);

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
