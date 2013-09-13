using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NCAA_PODMap : EntityTypeConfiguration<NCAA_POD>
    {
        public NCAA_PODMap()
        {
            // Primary Key
            this.HasKey(t => t.Pod);

            // Properties
            this.Property(t => t.Pod)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.Abbreviation)
                .HasMaxLength(6);

            this.Property(t => t.Color)
                .HasMaxLength(7);

            // Table & Column Mappings
            this.ToTable("NCAA_POD");
            this.Property(t => t.Pod).HasColumnName("Pod");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.Color).HasColumnName("Color");
        }
    }
}
