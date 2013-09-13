using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NCAA_PLAYERMap : EntityTypeConfiguration<NCAA_PLAYER>
    {
        public NCAA_PLAYERMap()
        {
            // Primary Key
            this.HasKey(t => t.UserID);

            // Properties
            this.Property(t => t.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UserName)
                .HasMaxLength(20);

            this.Property(t => t.Pod)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("NCAA_PLAYER");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Pod).HasColumnName("Pod");
            this.Property(t => t.Points).HasColumnName("Points");

            // Relationships
            this.HasOptional(t => t.NCAA_POD)
                .WithMany(t => t.NCAA_PLAYER)
                .HasForeignKey(d => d.Pod);

        }
    }
}
