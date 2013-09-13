using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class spt_valuesMap : EntityTypeConfiguration<spt_values>
    {
        public spt_valuesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.number, t.type });

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(35);

            this.Property(t => t.number)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.type)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("spt_values");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.number).HasColumnName("number");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.low).HasColumnName("low");
            this.Property(t => t.high).HasColumnName("high");
            this.Property(t => t.status).HasColumnName("status");
        }
    }
}
