using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.LOTW.Core.Models.Mapping
{
    public class ScheduleMap : EntityTypeConfiguration<Schedule>
    {
        public ScheduleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.GameCode)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Schedules");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.WeekId).HasColumnName("WeekId");
            this.Property(t => t.HomeId).HasColumnName("HomeId");
            this.Property(t => t.AwayId).HasColumnName("AwayId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.GameCode).HasColumnName("GameCode");
            this.Property(t => t.HomeTeamSpread).HasColumnName("HomeTeamSpread");
            this.Property(t => t.OverUnder).HasColumnName("OverUnder");

            // Relationships
            this.HasRequired(t => t.AwayTeam)
                .WithMany(t => t.Schedules)
                .HasForeignKey(d => d.AwayId);

            this.HasRequired(t => t.HomeTeam)
                .WithMany(t => t.Schedules1)
                .HasForeignKey(d => d.HomeId);

            this.HasRequired(t => t.Week)
                .WithMany(t => t.Schedules)
                .HasForeignKey(d => d.WeekId);

        }
    }
}
