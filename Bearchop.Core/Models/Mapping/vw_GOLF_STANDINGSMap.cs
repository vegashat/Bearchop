using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_GOLF_STANDINGSMap : EntityTypeConfiguration<vw_GOLF_STANDINGS>
    {
        public vw_GOLF_STANDINGSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.UserName });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("vw_GOLF_STANDINGS");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Points).HasColumnName("Points");
        }
    }
}
