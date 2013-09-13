using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class BIG12_SCHEDULEMap : EntityTypeConfiguration<BIG12_SCHEDULE>
    {
        public BIG12_SCHEDULEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Week, t.Team });

            // Properties
            this.Property(t => t.Team)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.Opponent)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("BIG12_SCHEDULE");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.Team).HasColumnName("Team");
            this.Property(t => t.Opponent).HasColumnName("Opponent");
            this.Property(t => t.TeamScore).HasColumnName("TeamScore");
            this.Property(t => t.OppScore).HasColumnName("OppScore");
        }
    }
}
