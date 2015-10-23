using GTAC.GTACAir.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Persistence.Entity.TypeConfigurations
{
    class CrewTypeConfiguration : AbstractTypeConfiguration<Crew>
    {
        public override void ConfigureFields()
        {
            Property(p => p.Id)
                .HasColumnOrder(0)
                .HasColumnName("CRW_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Name)
                .HasColumnOrder(1)
                .HasColumnName("CRW_NAME")
                .HasMaxLength(30)
                .IsRequired();

            Property(p => p.AnacCode)
                .HasColumnOrder(2)
                .HasColumnName("CRW_ANAC_CODE")
                .HasMaxLength(6)
                .IsRequired();

            Property(p => p.CompanyNumber)
                .HasColumnOrder(3)
                .HasColumnName("CRW_COMPANY_NUMBER")
                .HasMaxLength(8)
                .IsRequired();

            Property(p => p.Active)
                .HasColumnOrder(4)
                .HasColumnName("CRW_ACTIVE")
                .IsRequired();

            Property(p => p.Nickname)
                .HasColumnOrder(5)
                .HasColumnName("CRW_NICKNAME")
                .HasMaxLength(10)
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
            ToTable("CREW");
        }
    }
}
