using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.LOTW.Core.Models.Mapping
{
    public class vw_team_scheduleMap : EntityTypeConfiguration<vw_team_schedule>
    {
        public vw_team_scheduleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Week, t.Date, t.GameCode, t.Homeid, t.AwayId });

            // Properties
            this.Property(t => t.Week)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.GameCode)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.Homeid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AwayId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_team_schedule");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.HomeTeam).HasColumnName("HomeTeam");
            this.Property(t => t.AwayTeam).HasColumnName("AwayTeam");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.GameCode).HasColumnName("GameCode");
            this.Property(t => t.Homeid).HasColumnName("Homeid");
            this.Property(t => t.AwayId).HasColumnName("AwayId");
        }
    }
}
