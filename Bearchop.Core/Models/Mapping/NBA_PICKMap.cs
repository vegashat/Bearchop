using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NBA_PICKMap : EntityTypeConfiguration<NBA_PICK>
    {
        public NBA_PICKMap()
        {
            // Primary Key
            this.HasKey(t => t.Ball);

            // Properties
            this.Property(t => t.Owner)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("NBA_PICK");
            this.Property(t => t.Ball).HasColumnName("Ball");
            this.Property(t => t.Owner).HasColumnName("Owner");
            this.Property(t => t.Game).HasColumnName("Game");
            this.Property(t => t.Pick).HasColumnName("Pick");
        }
    }
}
