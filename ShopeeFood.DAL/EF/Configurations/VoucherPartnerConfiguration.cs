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
    public class VoucherPartnerConfiguration : IEntityTypeConfiguration<VoucherPartner>
    {
        public void Configure(EntityTypeBuilder<VoucherPartner> builder)
        {
            builder.ToTable("Vouchers_Partners");

            builder.HasKey(t => new { t.VoucherId, t.PartnerId });

            builder.HasOne(t => t.Voucher).WithMany(pc => pc.VoucherPartners).HasForeignKey(pc => pc.VoucherId);

            builder.HasOne(t => t.Partner).WithMany(pc => pc.VoucherPartners).HasForeignKey(pc => pc.PartnerId);
        }
    }
}
