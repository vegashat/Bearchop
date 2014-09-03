using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.LOTW.Core.Models.Mapping
{
    public class DivisionMap : EntityTypeConfiguration<Division>
    {
        public DivisionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Divisions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ConferenceId).HasColumnName("ConferenceId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
