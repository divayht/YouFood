using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

using YouFood.Domain.Model;

namespace YouFood.Data.Configurations
{
    public class DishesConfiguration : EntityTypeConfiguration<Dish>
    {
        public DishesConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Description");

            Property(x => x.Price)
                .HasColumnName("Price")
                .IsRequired();

            Property(x => x.Image)
                .HasColumnName("Image");

            Property(x => x.TimeToCook)
                .HasColumnName("TimeToCook");

            Property(x => x.DishTypeId)
                .HasColumnName("Type")
                .IsRequired();

            HasRequired(x => x.Specialty)
                .WithMany(x => x.Dishes)
                .HasForeignKey(x => x.SpecialtyId);

            Ignore(x => x.DishType);
        }
    }
}
