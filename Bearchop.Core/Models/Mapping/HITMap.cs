using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class HITMap : EntityTypeConfiguration<HIT>
    {
        public HITMap()
        {
            // Primary Key
            this.HasKey(t => t.Site);

            // Properties
            this.Property(t => t.Site)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HITS");
            this.Property(t => t.Site).HasColumnName("Site");
            this.Property(t => t.HitCount).HasColumnName("HitCount");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
        }
    }
}
