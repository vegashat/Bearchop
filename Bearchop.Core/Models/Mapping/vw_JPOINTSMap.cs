using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_JPOINTSMap : EntityTypeConfiguration<vw_JPOINTS>
    {
        public vw_JPOINTSMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserID, t.ContestID, t.ContestYear, t.Place, t.Champion, t.MVP, t.AllStar, t.Star, t.JPoints });

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

            this.Property(t => t.Champion)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.MVP)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AllStar)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Star)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.JPoints)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("vw_JPOINTS");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.ContestID).HasColumnName("ContestID");
            this.Property(t => t.ContestYear).HasColumnName("ContestYear");
            this.Property(t => t.Place).HasColumnName("Place");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.UserCount).HasColumnName("UserCount");
            this.Property(t => t.Champion).HasColumnName("Champion");
            this.Property(t => t.MVP).HasColumnName("MVP");
            this.Property(t => t.AllStar).HasColumnName("AllStar");
            this.Property(t => t.Star).HasColumnName("Star");
            this.Property(t => t.JPoints).HasColumnName("JPoints");
        }
    }
}
