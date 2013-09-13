using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class ERRORLOGMap : EntityTypeConfiguration<ERRORLOG>
    {
        public ERRORLOGMap()
        {
            // Primary Key
            this.HasKey(t => t.LogDate);

            // Properties
            this.Property(t => t.Exception)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ERRORLOG");
            this.Property(t => t.LogDate).HasColumnName("LogDate");
            this.Property(t => t.Exception).HasColumnName("Exception");
            this.Property(t => t.StackTrace).HasColumnName("StackTrace");
        }
    }
}
