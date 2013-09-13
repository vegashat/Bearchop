using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_user_scheduleMap : EntityTypeConfiguration<UserSchedule>
    {
        public vw_user_scheduleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.TeamID,t.Name, t.Opponent, t.Date, t.PickWeek, t.CurrentWeek });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TeamID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Opponent)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_user_schedule");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.Name).HasColumnName("name");
            this.Property(t => t.Opponent).HasColumnName("opponent");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.ScheduleWeek).HasColumnName("schedule_week");
            this.Property(t => t.PickWeek).HasColumnName("pick_week");
            this.Property(t => t.CurrentWeek).HasColumnName("CurrentWeek");
        }
    }
}
