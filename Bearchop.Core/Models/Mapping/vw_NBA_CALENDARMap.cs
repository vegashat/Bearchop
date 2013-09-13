using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_NBA_CALENDARMap : EntityTypeConfiguration<vw_NBA_CALENDAR>
    {
        public vw_NBA_CALENDARMap()
        {
            // Primary Key
            this.HasKey(t => t.GameDate);

            // Properties
            this.Property(t => t.GameTime)
                .HasMaxLength(4);

            this.Property(t => t.Team)
                .HasMaxLength(8000);

            this.Property(t => t.Owner)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_NBA_CALENDAR");
            this.Property(t => t.GameDate).HasColumnName("GameDate");
            this.Property(t => t.GameTime).HasColumnName("GameTime");
            this.Property(t => t.Team).HasColumnName("Team");
            this.Property(t => t.Premier).HasColumnName("Premier");
            this.Property(t => t.Tickets).HasColumnName("Tickets");
            this.Property(t => t.Owner).HasColumnName("Owner");
            this.Property(t => t.Picks).HasColumnName("Picks");
            this.Property(t => t.Pick).HasColumnName("Pick");
            this.Property(t => t.Ball).HasColumnName("Ball");
        }
    }
}
