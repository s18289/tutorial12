using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial12.Models;

namespace tutorial12.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.IdOrder)
                  .HasName("Order_pk");

            builder.Property(e => e.DateAccepted).HasColumnType("date")
                  .IsRequired();


            builder.Property(e => e.DateFinished)
                      .IsRequired();

            builder.Property(e => e.Notes).IsRequired().HasMaxLength(255);

        }
    }
}