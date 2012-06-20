using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using YouFood.Domain.Model;

namespace YouFood.Data.Configurations
{
    public class UsersConfiguration : EntityTypeConfiguration<User>
    {
        public UsersConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            Property(x => x.Password)
                .HasColumnName("Password")
                .IsRequired();

            HasRequired(x => x.Table)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.TableId);
        }
    }
}
