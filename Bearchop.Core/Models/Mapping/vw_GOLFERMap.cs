using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_GOLFERMap : EntityTypeConfiguration<vw_GOLFER>
    {
        public vw_GOLFERMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GolferID, t.Golfer, t.Country, t.Rank, t.Bonus });

            // Properties
            this.Property(t => t.GolferID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Golfer)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Major_Name)
                .HasMaxLength(16);

            this.Property(t => t.Course)
                .HasMaxLength(20);

            this.Property(t => t.Bonus)
                .IsRequired()
                .HasMaxLength(16);

            // Table & Column Mappings
            this.ToTable("vw_GOLFER");
            this.Property(t => t.GolferID).HasColumnName("GolferID");
            this.Property(t => t.Golfer).HasColumnName("Golfer");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Rank).HasColumnName("Rank");
            this.Property(t => t.Golfer_Value).HasColumnName("Golfer_Value");
            this.Property(t => t.Golfer_Points).HasColumnName("Golfer_Points");
            this.Property(t => t.Major_Name).HasColumnName("Major_Name");
            this.Property(t => t.Course).HasColumnName("Course");
            this.Property(t => t.Score).HasColumnName("Score");
            this.Property(t => t.ParPts).HasColumnName("ParPts");
            this.Property(t => t.Bonus).HasColumnName("Bonus");
            this.Property(t => t.BonusPts).HasColumnName("BonusPts");
            this.Property(t => t.TierPts).HasColumnName("TierPts");
            this.Property(t => t.TotalPts).HasColumnName("TotalPts");
        }
    }
}
