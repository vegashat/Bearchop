using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NB12_SCHEDULEMap : EntityTypeConfiguration<NB12_SCHEDULE>
    {
        public NB12_SCHEDULEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Week, t.Game });

            // Properties
            this.Property(t => t.D01_User)
                .HasMaxLength(15);

            this.Property(t => t.D02_User)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("NB12_SCHEDULE");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.Game).HasColumnName("Game");
            this.Property(t => t.WeekDate).HasColumnName("WeekDate");
            this.Property(t => t.D01).HasColumnName("D01");
            this.Property(t => t.D02).HasColumnName("D02");
            this.Property(t => t.D01_User).HasColumnName("D01_User");
            this.Property(t => t.D02_User).HasColumnName("D02_User");
            this.Property(t => t.D01_Points).HasColumnName("D01_Points");
            this.Property(t => t.D02_Points).HasColumnName("D02_Points");
        }
    }
}
