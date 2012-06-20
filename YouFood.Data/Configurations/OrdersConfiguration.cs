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

            HasRequired(x => x.Table)
                .WithMany()
                .HasForeignKey(x => x.TableId);

            Property(x => x.OrderStateId)
                .HasColumnName("State")
                .IsRequired();

            HasMany(x => x.Dishes)
                .WithMany()
                .Map(x =>
                {
                    x.ToTable("DishesInOrder");
                    x.MapLeftKey("OrderId");
                    x.MapRightKey("DishId");
                });

            Ignore(x => x.OrderState);

        }
    }
}
