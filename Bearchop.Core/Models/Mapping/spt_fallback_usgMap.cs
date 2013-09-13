using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class spt_fallback_usgMap : EntityTypeConfiguration<spt_fallback_usg>
    {
        public spt_fallback_usgMap()
        {
            // Primary Key
            this.HasKey(t => new { t.xserver_name, t.xdttm_ins, t.xdttm_last_ins_upd, t.dbid, t.segmap, t.lstart, t.sizepg, t.vstart });

            // Properties
            this.Property(t => t.xserver_name)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.dbid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.segmap)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.lstart)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.sizepg)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.vstart)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("spt_fallback_usg");
            this.Property(t => t.xserver_name).HasColumnName("xserver_name");
            this.Property(t => t.xdttm_ins).HasColumnName("xdttm_ins");
            this.Property(t => t.xdttm_last_ins_upd).HasColumnName("xdttm_last_ins_upd");
            this.Property(t => t.xfallback_vstart).HasColumnName("xfallback_vstart");
            this.Property(t => t.dbid).HasColumnName("dbid");
            this.Property(t => t.segmap).HasColumnName("segmap");
            this.Property(t => t.lstart).HasColumnName("lstart");
            this.Property(t => t.sizepg).HasColumnName("sizepg");
            this.Property(t => t.vstart).HasColumnName("vstart");
        }
    }
}
