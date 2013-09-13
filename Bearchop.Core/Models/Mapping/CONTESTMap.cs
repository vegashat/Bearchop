using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class CONTESTMap : EntityTypeConfiguration<CONTEST>
    {
        public CONTESTMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ContestID, t.ContestYear });

            // Properties
            this.Property(t => t.ContestID)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.ContestYear)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Winner)
                .HasMaxLength(50);

            this.Property(t => t.Picture)
                .HasMaxLength(50);

            this.Property(t => t.Caption)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CONTEST");
            this.Property(t => t.ContestID).HasColumnName("ContestID");
            this.Property(t => t.ContestYear).HasColumnName("ContestYear");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.RegisterDate).HasColumnName("RegisterDate");
            this.Property(t => t.Winner).HasColumnName("Winner");
            this.Property(t => t.Picture).HasColumnName("Picture");
            this.Property(t => t.Caption).HasColumnName("Caption");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.UserCount).HasColumnName("UserCount");
            this.Property(t => t.MidStart).HasColumnName("MidStart");
            this.Property(t => t.MidEnd).HasColumnName("MidEnd");

            // Relationships
            this.HasRequired(t => t.REF_CONTEST)
                .WithMany(t => t.CONTESTs)
                .HasForeignKey(d => d.ContestID);

        }
    }
}
