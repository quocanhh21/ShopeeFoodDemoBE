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
    public class OptionType_OptionItemConfiguration : IEntityTypeConfiguration<OptionType_OptionItem>
    {
        public void Configure(EntityTypeBuilder<OptionType_OptionItem> builder)
        {
            builder.ToTable("OptionTypes_OptionItems");

            builder.HasKey(t => new { t.OptionTypeId, t.OptionItemId });

            builder.HasOne(t => t.OptionType).WithMany(pc => pc.OptionType_OptionItem).HasForeignKey(pc=>pc.OptionTypeId);

            builder.HasOne(t => t.OptionItem).WithMany(pc => pc.OptionType_OptionItem).HasForeignKey(pc => pc.OptionItemId);
        }
    }
}
