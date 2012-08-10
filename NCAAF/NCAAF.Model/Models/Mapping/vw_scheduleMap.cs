using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace NCAAF.Model.Models.Mapping
{
    public class vw_scheduleMap : EntityTypeConfiguration<vw_schedule>
    {
        public vw_scheduleMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Date, t.HomeTeamId, t.HomeName, t.AwayTeamId, t.AwayName });

            // Properties
            this.Property(t => t.HomeTeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.HomeName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AwayTeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AwayName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_schedule");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.HomeTeamId).HasColumnName("HomeTeamId");
            this.Property(t => t.HomeName).HasColumnName("HomeName");
            this.Property(t => t.AwayTeamId).HasColumnName("AwayTeamId");
            this.Property(t => t.AwayName).HasColumnName("AwayName");
            this.Property(t => t.Week).HasColumnName("Week");
        }
    }
}
