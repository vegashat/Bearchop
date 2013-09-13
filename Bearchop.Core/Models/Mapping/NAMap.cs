using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NAMap : EntityTypeConfiguration<NA>
    {
        public NAMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Year, t.Sport, t.Category, t.UserID });

            // Properties
            this.Property(t => t.Year)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.Sport)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Category)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Team)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("NAS");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Sport).HasColumnName("Sport");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Team).HasColumnName("Team");
            this.Property(t => t.Points).HasColumnName("Points");
        }
    }
}
