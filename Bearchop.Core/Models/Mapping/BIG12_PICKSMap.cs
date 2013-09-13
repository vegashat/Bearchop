using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class BIG12_PICKSMap : EntityTypeConfiguration<BIG12_PICKS>
    {
        public BIG12_PICKSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.Week, t.Team });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Team)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Opponent)
                .HasMaxLength(15);

            this.Property(t => t.OrigGuess)
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("BIG12_PICKS");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.Team).HasColumnName("Team");
            this.Property(t => t.Opponent).HasColumnName("Opponent");
            this.Property(t => t.TeamGuess).HasColumnName("TeamGuess");
            this.Property(t => t.OppGuess).HasColumnName("OppGuess");
            this.Property(t => t.OrigGuess).HasColumnName("OrigGuess");
            this.Property(t => t.TradeDate).HasColumnName("TradeDate");
        }
    }
}
