using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

using YouFood.Domain.Model;

namespace YouFood.Data.Configurations
{
    public class SpecialtiesConfiguration : EntityTypeConfiguration<Specialty>
    {
        public SpecialtiesConfiguration()
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

            Property(x => x.IsActive)
                .HasColumnName("IsActive")
                .IsRequired();
        }
    }
}
