using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_user_weekly_scheduleMap : EntityTypeConfiguration<UserWeeklySchedule>
    {
        public vw_user_weekly_scheduleMap()
        {
            // Primary Key
            this.HasKey(t => new {  t.UserId,  t.TeamId, t.Name,  t.PickWeek });

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.TeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Week1Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week2Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week3Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week4Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week5Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week6Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week7Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week8Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week9Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week10Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week11Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week12Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week13Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week14Opponent)
                .HasMaxLength(50);

            this.Property(t => t.Week15Opponent)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_user_weekly_schedule");
            this.Property(t => t.UserId).HasColumnName("userid");
            this.Property(t => t.TeamId).HasColumnName("teamid");
            this.Property(t => t.Name).HasColumnName("name");
            this.Property(t => t.PickWeek).HasColumnName("pick_week");
            this.Property(t => t.Week1Opponent).HasColumnName("week1_opponent");
            this.Property(t => t.Week2Opponent).HasColumnName("week2_opponent");
            this.Property(t => t.Week3Opponent).HasColumnName("week3_opponent");
            this.Property(t => t.Week4Opponent).HasColumnName("week4_opponent");
            this.Property(t => t.Week5Opponent).HasColumnName("week5_opponent");
            this.Property(t => t.Week6Opponent).HasColumnName("week6_opponent");
            this.Property(t => t.Week7Opponent).HasColumnName("week7_opponent");
            this.Property(t => t.Week8Opponent).HasColumnName("week8_opponent");
            this.Property(t => t.Week9Opponent).HasColumnName("week9_opponent");
            this.Property(t => t.Week10Opponent).HasColumnName("week10_opponent");
            this.Property(t => t.Week11Opponent).HasColumnName("week11_opponent");
            this.Property(t => t.Week12Opponent).HasColumnName("week12_opponent");
            this.Property(t => t.Week13Opponent).HasColumnName("week13_opponent");
            this.Property(t => t.Week14Opponent).HasColumnName("week14_opponent");
            this.Property(t => t.Week15Opponent).HasColumnName("week15_opponent");
        }
    }
}
