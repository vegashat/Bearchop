using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class REF_CONTESTMap : EntityTypeConfiguration<REF_CONTEST>
    {
        public REF_CONTESTMap()
        {
            // Primary Key
            this.HasKey(t => t.ContestID);

            // Properties
            this.Property(t => t.ContestID)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.ContestName)
                .HasMaxLength(50);

            this.Property(t => t.ContestURL)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("REF_CONTEST");
            this.Property(t => t.ContestID).HasColumnName("ContestID");
            this.Property(t => t.ContestName).HasColumnName("ContestName");
            this.Property(t => t.Sequence).HasColumnName("Sequence");
            this.Property(t => t.ContestURL).HasColumnName("ContestURL");
        }
    }
}
