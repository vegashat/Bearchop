using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_COLFOOT_STANDINGSMap : EntityTypeConfiguration<vw_COLFOOT_STANDINGS>
    {
        public vw_COLFOOT_STANDINGSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.UserName });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("vw_COLFOOT_STANDINGS");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Points).HasColumnName("Points");
        }
    }
}
