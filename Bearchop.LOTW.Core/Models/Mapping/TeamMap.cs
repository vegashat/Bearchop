using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.LOTW.Core.Models.Mapping
{
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.Nickname)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Teams");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DivisionId).HasColumnName("DivisionId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Nickname).HasColumnName("Nickname");
        }
    }
}
