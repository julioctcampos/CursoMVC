using GTAC.GTACAir.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Persistence.Entity.TypeConfigurations
{
    class AircraftTypeConfiguration : AbstractTypeConfiguration<Aircraft>
    {
        public override void ConfigureFields()
        {
            Property(p => p.Id)
                .HasColumnOrder(0)
                .HasColumnName("AIC_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Model)
                .HasColumnOrder(1)
                .HasColumnName("AIC_MODEL")
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.Preffix)
                .HasColumnOrder(2)
                .HasColumnName("AIC_PREFFIX")
                .HasMaxLength(6)
                .IsRequired();

            Property(p => p.SeatCount)
                .HasColumnOrder(3)
                .HasColumnName("AIC_SEAT_COUNT")
                .IsOptional();

            Property(p => p.ManufacturerSite)
                .HasColumnOrder(4)
                .HasColumnName("AIC_MANUFACTURER_SITE")
                .HasMaxLength(100)
                .IsOptional();
        }

        public override void ConfigureForeignKeys()
        {

        }

        public override void ConfigureOthers()
        {

        }

        public override void ConfigurePrimaryKeys()
        {
            HasKey(p => p.Id);
        }

        public override void ConfigureTableName()
        {
            ToTable("AIRCRAFT");
        }
    }
}
