using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NB12_SCORESMap : EntityTypeConfiguration<NB12_SCORES>
    {
        public NB12_SCORESMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Pick, t.Week, t.UserName });

            // Properties
            this.Property(t => t.Pick)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(15);

            this.Property(t => t.Player)
                .HasMaxLength(25);

            this.Property(t => t.Pos)
                .IsFixedLength()
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("NB12_SCORES");
            this.Property(t => t.Pick).HasColumnName("Pick");
            this.Property(t => t.Week).HasColumnName("Week");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.Player).HasColumnName("Player");
            this.Property(t => t.Pos).HasColumnName("Pos");
            this.Property(t => t.Pass).HasColumnName("Pass");
            this.Property(t => t.Rush).HasColumnName("Rush");
            this.Property(t => t.Recv).HasColumnName("Recv");
            this.Property(t => t.TD).HasColumnName("TD");
            this.Property(t => t.Turnovers).HasColumnName("Turnovers");
            this.Property(t => t.Safeties).HasColumnName("Safeties");
            this.Property(t => t.PK3).HasColumnName("PK3");
            this.Property(t => t.PK5).HasColumnName("PK5");
            this.Property(t => t.XP).HasColumnName("XP");
            this.Property(t => t.PtsAllowed).HasColumnName("PtsAllowed");
            this.Property(t => t.YdsAllowed).HasColumnName("YdsAllowed");
            this.Property(t => t.Points).HasColumnName("Points");
        }
    }
}
