using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class GOLF_SCOREMap : EntityTypeConfiguration<GOLF_SCORE>
    {
        public GOLF_SCOREMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GolferID, t.Major });

            // Properties
            this.Property(t => t.GolferID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Major)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("GOLF_SCORE");
            this.Property(t => t.GolferID).HasColumnName("GolferID");
            this.Property(t => t.Major).HasColumnName("Major");
            this.Property(t => t.Score).HasColumnName("Score");
            this.Property(t => t.ParPts).HasColumnName("ParPts");
            this.Property(t => t.BonusPts).HasColumnName("BonusPts");
            this.Property(t => t.TierPts).HasColumnName("TierPts");
            this.Property(t => t.TotalPts).HasColumnName("TotalPts");

            // Relationships
            this.HasRequired(t => t.GOLF_MAJOR)
                .WithMany(t => t.GOLF_SCORE)
                .HasForeignKey(d => d.Major);
            this.HasRequired(t => t.GOLFER)
                .WithMany(t => t.GOLF_SCORE)
                .HasForeignKey(d => d.GolferID);

        }
    }
}
