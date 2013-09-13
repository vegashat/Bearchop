using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class BOWL_PICKSMap : EntityTypeConfiguration<BOWL_PICKS>
    {
        public BOWL_PICKSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.BowlID, t.UserID });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Winner)
                .HasMaxLength(15);

            this.Property(t => t.BowlName)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("BOWL_PICKS");
            this.Property(t => t.BowlID).HasColumnName("BowlID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Rank).HasColumnName("Rank");
            this.Property(t => t.Winner).HasColumnName("Winner");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.BowlName).HasColumnName("BowlName");

            // Relationships
            this.HasRequired(t => t.BOWL)
                .WithMany(t => t.BOWL_PICKS)
                .HasForeignKey(d => d.BowlID);

        }
    }
}
