using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

using YouFood.Domain.Model;

namespace YouFood.Data.Configurations
{
    public class OrdersConfiguration : EntityTypeConfiguration<Order>
    {
        public OrdersConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Price)
                .HasColumnName("Price")
                .IsRequired();

            Property(x => x.Date)
                .HasColumnName("Date");

            HasRequired(x => x.Table)
                .WithMany()
                .HasForeignKey(x => x.TableId);

            Property(x => x.OrderStateId)
                .HasColumnName("State")
                .IsRequired();

            Ignore(x => x.OrderState);

        }
    }
}
