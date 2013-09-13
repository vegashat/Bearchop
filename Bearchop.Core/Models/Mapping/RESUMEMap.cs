using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class RESUMEMap : EntityTypeConfiguration<RESUME>
    {
        public RESUMEMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.ContestID, t.ContestYear, t.Place });

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ContestID)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.ContestYear)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Place)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Points)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("RESUME");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.ContestID).HasColumnName("ContestID");
            this.Property(t => t.ContestYear).HasColumnName("ContestYear");
            this.Property(t => t.Place).HasColumnName("Place");
            this.Property(t => t.Points).HasColumnName("Points");

            // Relationships
            this.HasRequired(t => t.CONTEST)
                .WithMany(t => t.RESUMEs)
                .HasForeignKey(d => new { d.ContestID, d.ContestYear });
            this.HasRequired(t => t.JUSER)
                .WithMany(t => t.RESUMEs)
                .HasForeignKey(d => d.UserID);

        }
    }
}
