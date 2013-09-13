using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class GOLF_MAJORMap : EntityTypeConfiguration<GOLF_MAJOR>
    {
        public GOLF_MAJORMap()
        {
            // Primary Key
            this.HasKey(t => t.Major);

            // Properties
            this.Property(t => t.Major)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Course)
                .HasMaxLength(20);

            this.Property(t => t.Location)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("GOLF_MAJOR");
            this.Property(t => t.Major).HasColumnName("Major");
            this.Property(t => t.Course).HasColumnName("Course");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.Register_Date).HasColumnName("Register_Date");
            this.Property(t => t.Start_Date).HasColumnName("Start_Date");
            this.Property(t => t.End_Date).HasColumnName("End_Date");
        }
    }
}
