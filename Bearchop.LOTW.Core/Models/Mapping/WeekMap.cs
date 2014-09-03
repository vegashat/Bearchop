using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.LOTW.Core.Models.Mapping
{
    public class WeekMap : EntityTypeConfiguration<Week>
    {
        public WeekMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Weeks");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.BeginDate).HasColumnName("BeginDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
        }
    }
}
