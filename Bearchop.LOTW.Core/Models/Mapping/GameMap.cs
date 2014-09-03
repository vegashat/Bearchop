using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.LOTW.Core.Models.Mapping
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Games");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.WeekId).HasColumnName("WeekId");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.HomeTeam).HasColumnName("HomeTeam");
            this.Property(t => t.AwayTeam).HasColumnName("AwayTeam");
            this.Property(t => t.HomeTeamSpread).HasColumnName("HomeTeamSpread");
            this.Property(t => t.AwayTeamSpread).HasColumnName("AwayTeamSpread");
            this.Property(t => t.OverUnder).HasColumnName("OverUnder");
            this.Property(t => t.FinalScore).HasColumnName("FinalScore");
            this.Property(t => t.HomeTeamScore).HasColumnName("HomeTeamScore");
            this.Property(t => t.AwayTeamScore).HasColumnName("AwayTeamScore");

            // Relationships
            this.HasRequired(t => t.Week)
                .WithMany(t => t.Games)
                .HasForeignKey(d => d.WeekId);

        }
    }
}
