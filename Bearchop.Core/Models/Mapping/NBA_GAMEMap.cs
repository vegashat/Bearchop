using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NBA_GAMEMap : EntityTypeConfiguration<NBA_GAME>
    {
        public NBA_GAMEMap()
        {
            // Primary Key
            this.HasKey(t => t.GameDate);

            // Properties
            this.Property(t => t.Team)
                .IsRequired()
                .HasMaxLength(12);

            // Table & Column Mappings
            this.ToTable("NBA_GAME");
            this.Property(t => t.GameDate).HasColumnName("GameDate");
            this.Property(t => t.GameDateTime).HasColumnName("GameDateTime");
            this.Property(t => t.Team).HasColumnName("Team");
            this.Property(t => t.Premier).HasColumnName("Premier");
            this.Property(t => t.Tickets).HasColumnName("Tickets");
        }
    }
}
