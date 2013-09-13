using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NPTEAMMap : EntityTypeConfiguration<NPTEAM>
    {
        public NPTEAMMap()
        {
            // Primary Key
            this.HasKey(t => t.TeamID);

            // Properties
            this.Property(t => t.TeamID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.TeamName)
                .HasMaxLength(15);

            this.Property(t => t.LogoName)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("NPTEAM");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.TeamName).HasColumnName("TeamName");
            this.Property(t => t.TeamRank).HasColumnName("TeamRank");
            this.Property(t => t.LogoName).HasColumnName("LogoName");
        }
    }
}
