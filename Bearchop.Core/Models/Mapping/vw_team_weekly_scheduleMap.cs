using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class TeamWeeklyScheduleMap : EntityTypeConfiguration<TeamWeeklySchedule>
    {
        public TeamWeeklyScheduleMap()
        {
            // Primary Key
            this.HasKey(t => new { TeamId = t.TeamId, Name = t.Name });

            // Properties
            this.Property(t => t.TeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Week1Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week2Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week3Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week4Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week5Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week6Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week7Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week8Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week9Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week10Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week11Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week12Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week13Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week14Opponent)
                .HasMaxLength(52);

            this.Property(t => t.Week15Opponent)
                .HasMaxLength(52);

            // Table & Column Mappings
            this.ToTable("vw_team_Weekly_schedule");
            this.Property(t => t.TeamId).HasColumnName("TeamID");
            this.Property(t => t.Name).HasColumnName("name");
            this.Property(t => t.Week1Opponent).HasColumnName("Week1_Opponent");
            this.Property(t => t.Week2Opponent).HasColumnName("Week2_Opponent");
            this.Property(t => t.Week3Opponent).HasColumnName("Week3_Opponent");
            this.Property(t => t.Week4Opponent).HasColumnName("Week4_Opponent");
            this.Property(t => t.Week5Opponent).HasColumnName("Week5_Opponent");
            this.Property(t => t.Week6Opponent).HasColumnName("Week6_Opponent");
            this.Property(t => t.Week7Opponent).HasColumnName("Week7_Opponent");
            this.Property(t => t.Week8Opponent).HasColumnName("Week8_Opponent");
            this.Property(t => t.Week9Opponent).HasColumnName("Week9_Opponent");
            this.Property(t => t.Week10Opponent).HasColumnName("Week10_Opponent");
            this.Property(t => t.Week11Opponent).HasColumnName("Week11_Opponent");
            this.Property(t => t.Week12Opponent).HasColumnName("Week12_Opponent");
            this.Property(t => t.Week13Opponent).HasColumnName("Week13_Opponent");
            this.Property(t => t.Week14Opponent).HasColumnName("Week14_Opponent");
            this.Property(t => t.Week15Opponent).HasColumnName("Week15_Opponent");
        }
    }
}
