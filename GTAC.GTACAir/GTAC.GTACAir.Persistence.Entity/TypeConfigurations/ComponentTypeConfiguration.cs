using GTAC.GTACAir.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Persistence.Entity.TypeConfigurations
{
    class ComponentTypeConfiguration : AbstractTypeConfiguration<Component>
    {
        public override void ConfigureFields()
        {
            Property(p => p.Id)
                .HasColumnName("CMP_ID")
                .HasColumnOrder(0)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Title)
                .HasColumnOrder(1)
                .HasColumnName("CMP_TITLE")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Manufacturer)
                .HasColumnOrder(2)
                .HasColumnName("CMP_MANUFACTURER")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.AircraftId)
                .HasColumnOrder(3)
                .HasColumnName("AIR_ID")
                .IsRequired();
        }

        public override void ConfigureForeignKeys()
        {
            HasRequired(p => p.Aircraft)
                .WithMany(p => p.Components)
                .HasForeignKey(fk => fk.AircraftId)
                .WillCascadeOnDelete(true);
        }

        public override void ConfigureOthers()
        {
            
        }

        public override void ConfigurePrimaryKeys()
        {
            HasKey(pk => pk.Id);
        }

        public override void ConfigureTableName()
        {
            ToTable("COMPONENTS");
        }
    }
}
