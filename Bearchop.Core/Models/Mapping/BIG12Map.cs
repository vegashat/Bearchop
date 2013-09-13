using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class BIG12Map : EntityTypeConfiguration<BIG12>
    {
        public BIG12Map()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.Week });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("BIG12");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Wins).HasColumnName("Wins");
            this.Property(t => t.Losses).HasColumnName("Losses");
            this.Property(t => t.Diff).HasColumnName("Diff");
        }
    }
}
