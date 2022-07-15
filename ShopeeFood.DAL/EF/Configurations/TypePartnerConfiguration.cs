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
    public class TypePartnerConfiguration : IEntityTypeConfiguration<TypePartner>
    {
        public void Configure(EntityTypeBuilder<TypePartner> builder)
        {
            builder.ToTable("TypeParters");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
