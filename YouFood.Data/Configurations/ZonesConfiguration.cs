using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

using YouFood.Domain.Model;

namespace YouFood.Data.Configurations
{
    public class ZonesConfiguration : EntityTypeConfiguration<Zone>
    {
        public ZonesConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            HasRequired(x => x.Restaurant)
                .WithMany(x => x.Zones)
                .HasForeignKey(x => x.RestaurantId);
        }
    }
}
