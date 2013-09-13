using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NAS_TEAMMap : EntityTypeConfiguration<NAS_TEAM>
    {
        public NAS_TEAMMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Sport, t.Team, t.Year });

            // Properties
            this.Property(t => t.Sport)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Team)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Year)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.Division)
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("NAS_TEAM");
            this.Property(t => t.Sport).HasColumnName("Sport");
            this.Property(t => t.Team).HasColumnName("Team");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Division).HasColumnName("Division");
            this.Property(t => t.Wins).HasColumnName("Wins");
            this.Property(t => t.Playoff).HasColumnName("Playoff");
            this.Property(t => t.League).HasColumnName("League");
            this.Property(t => t.Finals).HasColumnName("Finals");
            this.Property(t => t.Champion).HasColumnName("Champion");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.Update_DtTm).HasColumnName("Update_DtTm");
        }
    }
}
