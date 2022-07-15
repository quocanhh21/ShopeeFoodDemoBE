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
    public class OptionItemConfiguration : IEntityTypeConfiguration<OptionItem>
    {
        public void Configure(EntityTypeBuilder<OptionItem> builder)
        {
            builder.ToTable("OptionItems");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.OptionName).IsRequired().HasMaxLength(100);
        }
    }
}
