using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NPStandingMap : EntityTypeConfiguration<NPStanding>
    {
        public NPStandingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.UserName });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("NPStandings");
            this.Property(t => t.Place).HasColumnName("Place");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.PotentialPoints).HasColumnName("PotentialPoints");
        }
    }
}
