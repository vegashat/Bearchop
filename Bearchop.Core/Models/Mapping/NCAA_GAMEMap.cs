using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NCAA_GAMEMap : EntityTypeConfiguration<NCAA_GAME>
    {
        public NCAA_GAMEMap()
        {
            // Primary Key
            this.HasKey(t => t.GameID);

            // Properties
            this.Property(t => t.GameID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.Location)
                .HasMaxLength(50);

            this.Property(t => t.Team1)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.Team2)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.Winner)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.NextGame)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.RegionID)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("NCAA_GAME");
            this.Property(t => t.GameID).HasColumnName("GameID");
            this.Property(t => t.Round).HasColumnName("Round");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.GameDate).HasColumnName("GameDate");
            this.Property(t => t.Team1).HasColumnName("Team1");
            this.Property(t => t.Team2).HasColumnName("Team2");
            this.Property(t => t.Team1Score).HasColumnName("Team1Score");
            this.Property(t => t.Team2Score).HasColumnName("Team2Score");
            this.Property(t => t.Winner).HasColumnName("Winner");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.NextGame).HasColumnName("NextGame");
            this.Property(t => t.RegionID).HasColumnName("RegionID");

            // Relationships
            this.HasOptional(t => t.NCAA_TEAM)
                .WithMany(t => t.NCAA_GAME)
                .HasForeignKey(d => d.Team1);
            this.HasOptional(t => t.NCAA_TEAM1)
                .WithMany(t => t.NCAA_GAME1)
                .HasForeignKey(d => d.Team2);

        }
    }
}
