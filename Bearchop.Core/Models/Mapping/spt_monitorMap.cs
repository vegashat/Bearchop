using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class spt_monitorMap : EntityTypeConfiguration<spt_monitor>
    {
        public spt_monitorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.lastrun, t.cpu_busy, t.io_busy, t.idle, t.pack_received, t.pack_sent, t.connections, t.pack_errors, t.total_read, t.total_write, t.total_errors });

            // Properties
            this.Property(t => t.cpu_busy)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.io_busy)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idle)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pack_received)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pack_sent)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.connections)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pack_errors)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.total_read)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.total_write)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.total_errors)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("spt_monitor");
            this.Property(t => t.lastrun).HasColumnName("lastrun");
            this.Property(t => t.cpu_busy).HasColumnName("cpu_busy");
            this.Property(t => t.io_busy).HasColumnName("io_busy");
            this.Property(t => t.idle).HasColumnName("idle");
            this.Property(t => t.pack_received).HasColumnName("pack_received");
            this.Property(t => t.pack_sent).HasColumnName("pack_sent");
            this.Property(t => t.connections).HasColumnName("connections");
            this.Property(t => t.pack_errors).HasColumnName("pack_errors");
            this.Property(t => t.total_read).HasColumnName("total_read");
            this.Property(t => t.total_write).HasColumnName("total_write");
            this.Property(t => t.total_errors).HasColumnName("total_errors");
        }
    }
}
