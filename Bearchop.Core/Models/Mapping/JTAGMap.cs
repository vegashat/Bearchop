using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class JTAGMap : EntityTypeConfiguration<JTAG>
    {
        public JTAGMap()
        {
            // Primary Key
            this.HasKey(t => t.Tag);

            // Properties
            this.Property(t => t.Tag)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Value)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("JTAG");
            this.Property(t => t.Tag).HasColumnName("Tag");
            this.Property(t => t.Value).HasColumnName("Value");
        }
    }
}
