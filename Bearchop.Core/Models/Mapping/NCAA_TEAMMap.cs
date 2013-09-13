using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NCAA_TEAMMap : EntityTypeConfiguration<NCAA_TEAM>
    {
        public NCAA_TEAMMap()
        {
            // Primary Key
            this.HasKey(t => t.TeamID);

            // Properties
            this.Property(t => t.TeamID)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.TeamName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.RegionID)
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("NCAA_TEAM");
            this.Property(t => t.TeamID).HasColumnName("TeamID");
            this.Property(t => t.TeamName).HasColumnName("TeamName");
            this.Property(t => t.Seed).HasColumnName("Seed");
            this.Property(t => t.RegionID).HasColumnName("RegionID");
        }
    }
}
