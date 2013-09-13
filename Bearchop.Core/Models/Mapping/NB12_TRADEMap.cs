using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class NB12_TRADEMap : EntityTypeConfiguration<NB12_TRADE>
    {
        public NB12_TRADEMap()
        {
            // Primary Key
            this.HasKey(t => t.TradeNumber);

            // Properties
            this.Property(t => t.TradeType)
                .IsFixedLength()
                .HasMaxLength(1);

            this.Property(t => t.FromUser)
                .HasMaxLength(15);

            this.Property(t => t.ToUser)
                .HasMaxLength(15);

            this.Property(t => t.FromPlayers)
                .HasMaxLength(150);

            this.Property(t => t.ToPlayers)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("NB12_TRADE");
            this.Property(t => t.TradeNumber).HasColumnName("TradeNumber");
            this.Property(t => t.TradeType).HasColumnName("TradeType");
            this.Property(t => t.TradeDate).HasColumnName("TradeDate");
            this.Property(t => t.FromUser).HasColumnName("FromUser");
            this.Property(t => t.ToUser).HasColumnName("ToUser");
            this.Property(t => t.FromPlayers).HasColumnName("FromPlayers");
            this.Property(t => t.ToPlayers).HasColumnName("ToPlayers");
            this.Property(t => t.Approved).HasColumnName("Approved");
        }
    }
}
