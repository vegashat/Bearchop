using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Bearchop.Core.Models.Mapping
{
    public class vw_GOLF_MAJORMap : EntityTypeConfiguration<vw_GOLF_MAJOR>
    {
        public vw_GOLF_MAJORMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Major, t.Current_Flag });

            // Properties
            this.Property(t => t.Major)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.Major_Name)
                .HasMaxLength(16);

            this.Property(t => t.Course)
                .HasMaxLength(20);

            this.Property(t => t.Location)
                .HasMaxLength(30);

            this.Property(t => t.Current_Flag)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.I)
                .HasMaxLength(2);

            this.Property(t => t.J)
                .HasMaxLength(2);

            // Table & Column Mappings
            this.ToTable("vw_GOLF_MAJOR");
            this.Property(t => t.Major).HasColumnName("Major");
            this.Property(t => t.Major_Name).HasColumnName("Major_Name");
            this.Property(t => t.Course).HasColumnName("Course");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.Register_Date).HasColumnName("Register_Date");
            this.Property(t => t.Start_Date).HasColumnName("Start_Date");
            this.Property(t => t.End_Date).HasColumnName("End_Date");
            this.Property(t => t.Current_Flag).HasColumnName("Current_Flag");
            this.Property(t => t.I).HasColumnName("I");
            this.Property(t => t.J).HasColumnName("J");
        }
    }
}
