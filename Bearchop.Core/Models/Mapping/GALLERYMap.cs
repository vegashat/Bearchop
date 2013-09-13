using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class GALLERYMap : EntityTypeConfiguration<GALLERY>
    {
        public GALLERYMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GName, t.GType, t.ImgName });

            // Properties
            this.Property(t => t.GName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.ImgName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Caption)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("GALLERY");
            this.Property(t => t.GName).HasColumnName("GName");
            this.Property(t => t.GType).HasColumnName("GType");
            this.Property(t => t.ImgName).HasColumnName("ImgName");
            this.Property(t => t.GIndex).HasColumnName("GIndex");
            this.Property(t => t.Caption).HasColumnName("Caption");
        }
    }
}
