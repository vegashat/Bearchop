using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NPROUNDMap : EntityTypeConfiguration<NPROUND>
    {
        public NPROUNDMap()
        {
            // Primary Key
            this.HasKey(t => t.RoundID);

            // Properties
            this.Property(t => t.RoundID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RoundName)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("NPROUND");
            this.Property(t => t.RoundID).HasColumnName("RoundID");
            this.Property(t => t.RoundName).HasColumnName("RoundName");
        }
    }
}
