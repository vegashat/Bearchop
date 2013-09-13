using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NPGAMEMap : EntityTypeConfiguration<NPGAME>
    {
        public NPGAMEMap()
        {
            // Primary Key
            this.HasKey(t => t.GameId);

            // Properties
            this.Property(t => t.SeriesId)
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("NPGAME");
            this.Property(t => t.GameId).HasColumnName("GameId");
            this.Property(t => t.SeriesId).HasColumnName("SeriesId");
            this.Property(t => t.Game).HasColumnName("Game");
            this.Property(t => t.GameDateTime).HasColumnName("GameDateTime");
            this.Property(t => t.Team1Score).HasColumnName("Team1Score");
            this.Property(t => t.Team2Score).HasColumnName("Team2Score");
        }
    }
}
