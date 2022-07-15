using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopeeFood.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Configurations
{
    public class OptionTypes_ItemsConfiguration : IEntityTypeConfiguration<OptionType_Item>
    {
        public void Configure(EntityTypeBuilder<OptionType_Item> builder)
        {
            builder.ToTable("OptionTypes_Items");

            builder.HasKey(t => new { t.OptionTypeId, t.ItemId });

            builder.HasOne(oi => oi.OptionType).WithMany(o => o.OptionType_Item).HasForeignKey(oi => oi.OptionTypeId);

            builder.HasOne(oi => oi.Item).WithMany(o => o.OptionType_Item).HasForeignKey(oi => oi.ItemId);
        }
    }
}
