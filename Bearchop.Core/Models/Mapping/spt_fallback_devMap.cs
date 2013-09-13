using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class spt_fallback_devMap : EntityTypeConfiguration<spt_fallback_dev>
    {
        public spt_fallback_devMap()
        {
            // Primary Key
            this.HasKey(t => new { t.xserver_name, t.xdttm_ins, t.xdttm_last_ins_upd, t.low, t.high, t.status, t.name, t.phyname });

            // Properties
            this.Property(t => t.xserver_name)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.xfallback_drive)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.low)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.high)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.status)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.phyname)
                .IsRequired()
                .HasMaxLength(127);

            // Table & Column Mappings
            this.ToTable("spt_fallback_dev");
            this.Property(t => t.xserver_name).HasColumnName("xserver_name");
            this.Property(t => t.xdttm_ins).HasColumnName("xdttm_ins");
            this.Property(t => t.xdttm_last_ins_upd).HasColumnName("xdttm_last_ins_upd");
            this.Property(t => t.xfallback_low).HasColumnName("xfallback_low");
            this.Property(t => t.xfallback_drive).HasColumnName("xfallback_drive");
            this.Property(t => t.low).HasColumnName("low");
            this.Property(t => t.high).HasColumnName("high");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.phyname).HasColumnName("phyname");
        }
    }
}
