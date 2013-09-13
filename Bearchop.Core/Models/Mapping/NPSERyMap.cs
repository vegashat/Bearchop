using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NPSERyMap : EntityTypeConfiguration<NPSERy>
    {
        public NPSERyMap()
        {
            // Primary Key
            this.HasKey(t => t.SeriesID);

            // Properties
            this.Property(t => t.SeriesID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Division)
                .HasMaxLength(20);

            this.Property(t => t.Team1)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Team2)
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("NPSERIES");
            this.Property(t => t.SeriesID).HasColumnName("SeriesID");
            this.Property(t => t.RoundId).HasColumnName("RoundId");
            this.Property(t => t.Division).HasColumnName("Division");
            this.Property(t => t.Team1).HasColumnName("Team1");
            this.Property(t => t.Team1Wins).HasColumnName("Team1Wins");
            this.Property(t => t.Team2).HasColumnName("Team2");
            this.Property(t => t.Team2Wins).HasColumnName("Team2Wins");
            this.Property(t => t.SeriesWon).HasColumnName("SeriesWon");
        }
    }
}
