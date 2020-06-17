using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial12.Models;

namespace tutorial12.Configurations
{
    public class Confectionery_OrderConfiguration : IEntityTypeConfiguration<Confectionery_Order>
    {
        public void Configure(EntityTypeBuilder<Confectionery_Order> builder)
        {
            builder.HasKey(e => new { e.IdConfectionery, e.IdOrder });
            builder.Property(e => e.Quantity)
                     .IsRequired();

            builder.HasOne(e => e.IdConfectioneryNav).WithMany().HasForeignKey(e => e.IdConfectionery).HasConstraintName("idConfectionery");
            builder.HasOne(e => e.IdOrderNav).WithMany().HasForeignKey(e => e.IdOrder).HasConstraintName("idOrder");
            builder.Property(e => e.Notes).IsRequired().HasMaxLength(255).HasDefaultValue("None");
        }
    }
}