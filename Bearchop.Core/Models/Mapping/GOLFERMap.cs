using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class GOLFERMap : EntityTypeConfiguration<GOLFER>
    {
        public GOLFERMap()
        {
            // Primary Key
            this.HasKey(t => t.GolferID);

            // Properties
            this.Property(t => t.GolferID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Golfer1)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("GOLFER");
            this.Property(t => t.GolferID).HasColumnName("GolferID");
            this.Property(t => t.Golfer1).HasColumnName("Golfer");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Rank).HasColumnName("Rank");
            this.Property(t => t.Golfer_Value).HasColumnName("Golfer_Value");
            this.Property(t => t.Golfer_Points).HasColumnName("Golfer_Points");
        }
    }
}
