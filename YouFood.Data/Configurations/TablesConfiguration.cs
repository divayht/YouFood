using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

using YouFood.Domain.Model;

namespace YouFood.Data.Configurations
{
    public class TablesConfiguration : EntityTypeConfiguration<Table>
    {
        public TablesConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            HasRequired(x => x.Zone)
                .WithMany(x => x.Tables)
                .HasForeignKey(x => x.ZoneId);
        }
    }
}
