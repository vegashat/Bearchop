using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class MSreplication_optionsMap : EntityTypeConfiguration<MSreplication_options>
    {
        public MSreplication_optionsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.optname, t.value, t.major_version, t.minor_version, t.revision, t.install_failures });

            // Properties
            this.Property(t => t.optname)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.major_version)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.minor_version)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.revision)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.install_failures)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("MSreplication_options");
            this.Property(t => t.optname).HasColumnName("optname");
            this.Property(t => t.value).HasColumnName("value");
            this.Property(t => t.major_version).HasColumnName("major_version");
            this.Property(t => t.minor_version).HasColumnName("minor_version");
            this.Property(t => t.revision).HasColumnName("revision");
            this.Property(t => t.install_failures).HasColumnName("install_failures");
        }
    }
}
