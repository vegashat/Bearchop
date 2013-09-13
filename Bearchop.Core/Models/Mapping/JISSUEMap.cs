using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class JISSUEMap : EntityTypeConfiguration<JISSUE>
    {
        public JISSUEMap()
        {
            // Primary Key
            this.HasKey(t => t.Issue);

            // Properties
            this.Property(t => t.Issue)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Title)
                .HasMaxLength(80);

            this.Property(t => t.TitleColor)
                .HasMaxLength(20);

            this.Property(t => t.Caption)
                .HasMaxLength(60);

            // Table & Column Mappings
            this.ToTable("JISSUE");
            this.Property(t => t.Issue).HasColumnName("Issue");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.TitleColor).HasColumnName("TitleColor");
            this.Property(t => t.Caption).HasColumnName("Caption");
            this.Property(t => t.Details).HasColumnName("Details");
        }
    }
}
