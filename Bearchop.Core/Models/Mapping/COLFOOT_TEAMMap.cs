using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class COLFOOT_TEAMMap : EntityTypeConfiguration<COLFOOT_TEAM>
    {
        public COLFOOT_TEAMMap()
        {
            // Primary Key
            this.HasKey(t => t.TeamID);

            // Properties
            this.Property(t => t.TeamID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Conference)
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("COLFOOT_TEAM");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Conference).HasColumnName("Conference");
            this.Property(t => t.OPrice).HasColumnName("OPrice");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Wins).HasColumnName("Wins");
            this.Property(t => t.Losses).HasColumnName("Losses");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.OwnedBy).HasColumnName("OwnedBy");
            this.Property(t => t.RealValue).HasColumnName("RealValue");
            this.Property(t => t.IsSelectable).HasColumnName("IsSelectable");
        }
    }
}
