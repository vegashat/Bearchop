using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NCAAFootballWeekMap : EntityTypeConfiguration<NCAAFootballWeek>
    {
        public NCAAFootballWeekMap()
        {
            // Primary Key
            this.HasKey(t => t.Number);

            // Properties
            this.Property(t => t.Number)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("NCAAFootballWeek");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.BeginDate).HasColumnName("BeginDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
        }
    }
}
