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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.Order).WithMany(o => o.OrderDetails).HasForeignKey(d=>d.OrderForeignKey).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Item).WithMany(i => i.OrderDetails).HasForeignKey(d=>d.ItemForeignKey).OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
