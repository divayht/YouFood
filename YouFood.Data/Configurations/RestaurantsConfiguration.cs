using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;

using YouFood.Domain.Model;

namespace YouFood.Data.Configurations
{
    public class RestaurantsConfiguration : EntityTypeConfiguration<Restaurant>
    {
        public RestaurantsConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            HasRequired(x => x.Corporate)
                .WithMany(x => x.Restaurants)
                .HasForeignKey(x => x.CorporateId);
        }
    }
}
