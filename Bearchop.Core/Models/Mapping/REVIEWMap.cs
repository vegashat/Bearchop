using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class REVIEWMap : EntityTypeConfiguration<REVIEW>
    {
        public REVIEWMap()
        {
            // Primary Key
            this.HasKey(t => t.ReviewID);

            // Properties
            this.Property(t => t.ReviewID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ReviewType)
                .HasMaxLength(10);

            this.Property(t => t.Author)
                .HasMaxLength(50);

            this.Property(t => t.Venue)
                .HasMaxLength(50);

            this.Property(t => t.Attendees)
                .HasMaxLength(100);

            this.Property(t => t.ImagePath)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("REVIEWS");
            this.Property(t => t.ReviewID).HasColumnName("ReviewID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.ReviewDate).HasColumnName("ReviewDate");
            this.Property(t => t.ReviewType).HasColumnName("ReviewType");
            this.Property(t => t.RecentFlag).HasColumnName("RecentFlag");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.Venue).HasColumnName("Venue");
            this.Property(t => t.Attendees).HasColumnName("Attendees");
            this.Property(t => t.ImagePath).HasColumnName("ImagePath");
            this.Property(t => t.Commentary).HasColumnName("Commentary");
        }
    }
}
