using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.LOTW.Core.Models.Mapping
{
    public class PickMap : EntityTypeConfiguration<Pick>
    {
        public PickMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Picks");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.WeekId).HasColumnName("WeekId");
            this.Property(t => t.GameId).HasColumnName("GameId");
            this.Property(t => t.Team).HasColumnName("Team");
            this.Property(t => t.TypeValue).HasColumnName("TypeValue");
            this.Property(t => t.OverUnderValue).HasColumnName("OverUnderValue");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.HasOverUnder).HasColumnName("HasOverUnder");

            // Relationships
            this.HasRequired(t => t.Game)
                .WithMany(t => t.Picks)
                .HasForeignKey(d => d.GameId);
            this.HasRequired(t => t.LOTWUser)
                .WithMany(t => t.Picks)
                .HasForeignKey(d => d.UserId);
            this.HasRequired(t => t.Week)
                .WithMany(t => t.Picks)
                .HasForeignKey(d => d.WeekId);

        }
    }
}
