using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using YouFood.Domain.Model;

namespace YouFood.Data.Configurations
{
    public class CartLinesConfiguration : EntityTypeConfiguration<CartLine>
    {
        public CartLinesConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasRequired(x => x.Order)
                .WithMany(c => c.CartLines)
                .HasForeignKey(x => x.OrderId);

            HasRequired(x => x.Dish)
                .WithMany()
                .HasForeignKey(x => x.DishId);

            ToTable("CartLines");
        }
    }
}
