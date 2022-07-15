using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopeeFood.DAL.EF.Entities;
using ShopeeFood.DAL.EF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFood.DAL.EF.Configurations
{
    public class OptionTypeConfiguration : IEntityTypeConfiguration<OptionType>
    {
        public void Configure(EntityTypeBuilder<OptionType> builder)
        {
            builder.ToTable("OptionTypes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.IsRequired).IsRequired().HasDefaultValue(StatusOptionType.Optional);

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}
