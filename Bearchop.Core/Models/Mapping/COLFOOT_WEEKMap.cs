using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class COLFOOT_WEEKMap : EntityTypeConfiguration<COLFOOT_WEEK>
    {
        public COLFOOT_WEEKMap()
        {
            // Primary Key
            this.HasKey(t => t.CurrentWeek);

            // Properties
            this.Property(t => t.TueGames)
                .HasMaxLength(500);

            this.Property(t => t.WedGames)
                .HasMaxLength(500);

            this.Property(t => t.ThurGames)
                .HasMaxLength(500);

            this.Property(t => t.FriGames)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("COLFOOT_WEEK");
            this.Property(t => t.CurrentWeek).HasColumnName("CurrentWeek");
            this.Property(t => t.TueGames).HasColumnName("TueGames");
            this.Property(t => t.WedGames).HasColumnName("WedGames");
            this.Property(t => t.ThurGames).HasColumnName("ThurGames");
            this.Property(t => t.FriGames).HasColumnName("FriGames");
        }
    }
}
