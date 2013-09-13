using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_NBA_HOPPERMap : EntityTypeConfiguration<vw_NBA_HOPPER>
    {
        public vw_NBA_HOPPERMap()
        {
            // Primary Key
            this.HasKey(t => t.Owner);

            // Properties
            this.Property(t => t.Owner)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Last_Team)
                .HasMaxLength(21);

            this.Property(t => t.Team)
                .HasMaxLength(12);

            // Table & Column Mappings
            this.ToTable("vw_NBA_HOPPER");
            this.Property(t => t.Owner).HasColumnName("Owner");
            this.Property(t => t.Picks_Made).HasColumnName("Picks_Made");
            this.Property(t => t.Picks_Remaining).HasColumnName("Picks_Remaining");
            this.Property(t => t.Last_Pick).HasColumnName("Last_Pick");
            this.Property(t => t.Last_Game).HasColumnName("Last_Game");
            this.Property(t => t.Last_Team).HasColumnName("Last_Team");
            this.Property(t => t.Team).HasColumnName("Team");
        }
    }
}
