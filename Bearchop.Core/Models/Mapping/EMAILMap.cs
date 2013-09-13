using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class EMAILMap : EntityTypeConfiguration<EMAIL>
    {
        public EMAILMap()
        {
            // Primary Key
            this.HasKey(t => t.EmailID);

            // Properties
            this.Property(t => t.EmailMessage)
                .HasMaxLength(8000);

            // Table & Column Mappings
            this.ToTable("EMAIL");
            this.Property(t => t.EmailID).HasColumnName("EmailID");
            this.Property(t => t.EmailMessage).HasColumnName("EmailMessage");
        }
    }
}
