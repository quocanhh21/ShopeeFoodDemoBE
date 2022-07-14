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
    public class PartnerConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.ToTable("Partners");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.PartnerName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Address).IsRequired().HasMaxLength(200);

            builder.Property(x => x.OpenTime).IsRequired();

            builder.Property(x => x.CloseTime).IsRequired();

            builder.Property(x => x.Status).HasDefaultValue(Status.Inactive);

            builder.HasOne(p => p.TypePartner).WithMany(t => t.Partners).HasForeignKey(p=>p.TypePartnerForeignKey);

            builder.HasOne(p => p.District).WithMany(d => d.Partners).HasForeignKey(p=>p.DistrictForeignKey);
        }
    }
}
