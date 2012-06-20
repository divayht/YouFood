using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

using YouFood.Domain.Model;

namespace YouFood.Data.Configurations
{
    public class CorporatesConfiguration : EntityTypeConfiguration<Corporate>
    {
        public CorporatesConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();
        }
    }
}
