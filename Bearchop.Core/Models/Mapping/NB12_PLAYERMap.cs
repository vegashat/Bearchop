using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NB12_PLAYERMap : EntityTypeConfiguration<NB12_PLAYER>
    {
        public NB12_PLAYERMap()
        {
            // Primary Key
            this.HasKey(t => t.Draft_Order);

            // Properties
            this.Property(t => t.UserName)
                .HasMaxLength(15);

            this.Property(t => t.EmailAddress)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("NB12_PLAYER");
            this.Property(t => t.Draft_Order).HasColumnName("Draft_Order");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.Wins).HasColumnName("Wins");
            this.Property(t => t.Losses).HasColumnName("Losses");
            this.Property(t => t.Ties).HasColumnName("Ties");
            this.Property(t => t.Points).HasColumnName("Points");
        }
    }
}
