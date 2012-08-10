using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace NCAAF.Model.Models.Mapping
{
    public class ScheduleMap : EntityTypeConfiguration<Schedule>
    {
        public ScheduleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.HomeTeamId, t.AwayTeamId, t.Date });

            // Properties
            this.Property(t => t.HomeTeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AwayTeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Schedule");
            this.Property(t => t.HomeTeamId).HasColumnName("HomeTeamId");
            this.Property(t => t.AwayTeamId).HasColumnName("AwayTeamId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Week).HasColumnName("Week");

            // Relationships
            this.HasRequired(t => t.Team)
                .WithMany(t => t.Schedules)
                .HasForeignKey(d => d.AwayTeamId);
            this.HasOptional(t => t.Week1)
                .WithMany(t => t.Schedules)
                .HasForeignKey(d => d.Week);
            this.HasRequired(t => t.Team1)
                .WithMany(t => t.Schedules1)
                .HasForeignKey(d => d.HomeTeamId);

        }
    }
}
