using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace NCAAF.Model.Models.Mapping
{
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
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
            this.ToTable("Team");
            this.Property(t => t.TeamId).HasColumnName("TeamId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.IsSelectable).HasColumnName("IsSelectable");
        }
    }
}
