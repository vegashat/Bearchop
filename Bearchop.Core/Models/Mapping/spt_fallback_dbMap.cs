using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class spt_fallback_dbMap : EntityTypeConfiguration<spt_fallback_db>
    {
        public spt_fallback_dbMap()
        {
            // Primary Key
            this.HasKey(t => new { t.xserver_name, t.xdttm_ins, t.xdttm_last_ins_upd, t.name, t.dbid, t.status, t.version });

            // Properties
            this.Property(t => t.xserver_name)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.dbid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.status)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.version)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("spt_fallback_db");
            this.Property(t => t.xserver_name).HasColumnName("xserver_name");
            this.Property(t => t.xdttm_ins).HasColumnName("xdttm_ins");
            this.Property(t => t.xdttm_last_ins_upd).HasColumnName("xdttm_last_ins_upd");
            this.Property(t => t.xfallback_dbid).HasColumnName("xfallback_dbid");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.dbid).HasColumnName("dbid");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.version).HasColumnName("version");
        }
    }
}
