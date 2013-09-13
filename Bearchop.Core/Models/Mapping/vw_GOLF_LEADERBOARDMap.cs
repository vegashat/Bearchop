using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_GOLF_LEADERBOARDMap : EntityTypeConfiguration<vw_GOLF_LEADERBOARD>
    {
        public vw_GOLF_LEADERBOARDMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GolferID, t.Golfer, t.Country });

            // Properties
            this.Property(t => t.GolferID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Golfer)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("vw_GOLF_LEADERBOARD");
            this.Property(t => t.GolferID).HasColumnName("GolferID");
            this.Property(t => t.Golfer).HasColumnName("Golfer");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Golfer_Value).HasColumnName("Golfer_Value");
            this.Property(t => t.Masters).HasColumnName("Masters");
            this.Property(t => t.USOpen).HasColumnName("USOpen");
            this.Property(t => t.British).HasColumnName("British");
            this.Property(t => t.PGA).HasColumnName("PGA");
            this.Property(t => t.Golfer_Points).HasColumnName("Golfer_Points");
        }
    }
}
