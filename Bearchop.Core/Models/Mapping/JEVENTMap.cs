using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class JEVENTMap : EntityTypeConfiguration<JEVENT>
    {
        public JEVENTMap()
        {
            // Primary Key
            this.HasKey(t => t.EventID);

            // Properties
            this.Property(t => t.EventType)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.Event)
                .IsRequired()
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("JEVENT");
            this.Property(t => t.EventID).HasColumnName("EventID");
            this.Property(t => t.EventMonth).HasColumnName("EventMonth");
            this.Property(t => t.EventDay).HasColumnName("EventDay");
            this.Property(t => t.EventType).HasColumnName("EventType");
            this.Property(t => t.Event).HasColumnName("Event");
        }
    }
}
