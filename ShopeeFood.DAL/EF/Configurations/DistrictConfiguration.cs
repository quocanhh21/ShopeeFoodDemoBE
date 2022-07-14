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
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("Districts");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(100);

            builder.Property(x => x.Status).HasDefaultValue(Status.Inactive);

            builder.HasOne(d => d.City).WithMany(c => c.Districts).HasForeignKey(d=>d.CityForeignKey);
        }
    }
}
