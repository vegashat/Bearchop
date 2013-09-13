using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class LOYALTYMap : EntityTypeConfiguration<LOYALTY>
    {
        public LOYALTYMap()
        {
            // Primary Key
            this.HasKey(t => new { t.League, t.TeamName });

            // Properties
            this.Property(t => t.League)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.TeamName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Division)
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("LOYALTY");
            this.Property(t => t.League).HasColumnName("League");
            this.Property(t => t.TeamName).HasColumnName("TeamName");
            this.Property(t => t.Division).HasColumnName("Division");
        }
    }
}
