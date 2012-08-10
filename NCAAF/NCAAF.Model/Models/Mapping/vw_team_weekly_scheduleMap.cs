using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace NCAAF.Model.Models.Mapping
{
    public class vw_team_weekly_scheduleMap : EntityTypeConfiguration<vw_team_weekly_schedule>
    {
        public vw_team_weekly_scheduleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TeamID, t.name });

            // Properties
            this.Property(t => t.TeamID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.week1_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week2_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week3_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week4_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week5_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week6_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week7_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week8_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week9_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week10_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week11_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week12_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week13_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week14_opponent)
                .HasMaxLength(52);

            this.Property(t => t.week15_opponent)
                .HasMaxLength(52);

            // Table & Column Mappings
            this.ToTable("vw_team_weekly_schedule");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.week1_opponent).HasColumnName("week1_opponent");
            this.Property(t => t.week2_opponent).HasColumnName("week2_opponent");
            this.Property(t => t.week3_opponent).HasColumnName("week3_opponent");
            this.Property(t => t.week4_opponent).HasColumnName("week4_opponent");
            this.Property(t => t.week5_opponent).HasColumnName("week5_opponent");
            this.Property(t => t.week6_opponent).HasColumnName("week6_opponent");
            this.Property(t => t.week7_opponent).HasColumnName("week7_opponent");
            this.Property(t => t.week8_opponent).HasColumnName("week8_opponent");
            this.Property(t => t.week9_opponent).HasColumnName("week9_opponent");
            this.Property(t => t.week10_opponent).HasColumnName("week10_opponent");
            this.Property(t => t.week11_opponent).HasColumnName("week11_opponent");
            this.Property(t => t.week12_opponent).HasColumnName("week12_opponent");
            this.Property(t => t.week13_opponent).HasColumnName("week13_opponent");
            this.Property(t => t.week14_opponent).HasColumnName("week14_opponent");
            this.Property(t => t.week15_opponent).HasColumnName("week15_opponent");
        }
    }
}
