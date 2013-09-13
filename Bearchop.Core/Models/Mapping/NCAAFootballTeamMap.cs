using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NCAAFootballTeamMap : EntityTypeConfiguration<NCAAFootballTeam>
    {
        public NCAAFootballTeamMap()
        {
            // Primary Key
            this.HasKey(t => t.TeamId);

            // Properties
            this.Property(t => t.TeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("NCAAFootballTeam");
            this.Property(t => t.TeamId).HasColumnName("TeamId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.IsSelectable).HasColumnName("IsSelectable");
            this.Property(t => t.JeauxTeamId).HasColumnName("JeauxTeamId");
        }
    }
}
