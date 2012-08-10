using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace NCAAF.Model.Models.Mapping
{
    public class vw_user_scheduleMap : EntityTypeConfiguration<vw_user_schedule>
    {
        public vw_user_scheduleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.TeamID, t.name, t.opponent, t.Date, t.pick_week, t.CurrentWeek });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TeamID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.opponent)
                .IsRequired()
                .HasMaxLength(51);

            // Table & Column Mappings
            this.ToTable("vw_user_schedule");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.opponent).HasColumnName("opponent");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.schedule_week).HasColumnName("schedule_week");
            this.Property(t => t.pick_week).HasColumnName("pick_week");
            this.Property(t => t.CurrentWeek).HasColumnName("CurrentWeek");
        }
    }
}
