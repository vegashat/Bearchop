using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NCAAFootballScheduleMap : EntityTypeConfiguration<NCAAFootballSchedule>
    {
        public NCAAFootballScheduleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.HomeTeamId, t.AwayTeamId, t.Date });

            // Properties
            this.Property(t => t.HomeTeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AwayTeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("NCAAFootballSchedule");
            this.Property(t => t.HomeTeamId).HasColumnName("HomeTeamId");
            this.Property(t => t.AwayTeamId).HasColumnName("AwayTeamId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.GameCode).HasColumnName("GameCode");
            this.Property(t => t.IsFinal).HasColumnName("IsFinal");
        }
    }
}
