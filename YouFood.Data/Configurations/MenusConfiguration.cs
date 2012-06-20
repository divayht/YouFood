using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

using YouFood.Domain.Model;

namespace YouFood.Data.Configurations
{
    public class MenusConfiguration : EntityTypeConfiguration<Menu>
    {
        public MenusConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            HasRequired(x => x.Specialty)
                .WithMany()
                .HasForeignKey(x => x.SpecialtyId);

            HasMany(x => x.Dishes)
                .WithMany()
                .Map(x =>
                {
                    x.ToTable("DishesInMenu");
                    x.MapLeftKey("MenuId");
                    x.MapRightKey("DishId");
                });
        }
    }
}
