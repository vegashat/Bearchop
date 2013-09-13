using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class TWOTKMap : EntityTypeConfiguration<TWOTK>
    {
        public TWOTKMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.PostDate });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("TWOTK");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.PostDate).HasColumnName("PostDate");
            this.Property(t => t.Pushups).HasColumnName("Pushups");
            this.Property(t => t.Situps).HasColumnName("Situps");
            this.Property(t => t.PushupsYTD).HasColumnName("PushupsYTD");
            this.Property(t => t.SitupsYTD).HasColumnName("SitupsYTD");
            this.Property(t => t.PushupsAvg).HasColumnName("PushupsAvg");
            this.Property(t => t.SitupsAvg).HasColumnName("SitupsAvg");
            this.Property(t => t.PushupsPace).HasColumnName("PushupsPace");
            this.Property(t => t.SitupsPace).HasColumnName("SitupsPace");
            this.Property(t => t.DailyAvg).HasColumnName("DailyAvg");
            this.Property(t => t.PaceYTD).HasColumnName("PaceYTD");
        }
    }
}
