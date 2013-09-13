using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class AUDIT_LOGMap : EntityTypeConfiguration<AUDIT_LOG>
    {
        public AUDIT_LOGMap()
        {
            // Primary Key
            this.HasKey(t => t.Audit_ID);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("AUDIT_LOG");
            this.Property(t => t.Audit_ID).HasColumnName("Audit_ID");
            this.Property(t => t.Audit_Dttm).HasColumnName("Audit_Dttm");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
