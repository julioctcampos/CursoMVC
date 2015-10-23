using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Persistence.Entity.TypeConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Persistence.Entity.Context
{
    public class GTACAirDbContext : DbContext
    {
        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<Crew> Crews { get; set; }

        public GTACAirDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AircraftTypeConfiguration());
            modelBuilder.Configurations.Add(new CrewTypeConfiguration());
            modelBuilder.Configurations.Add(new ComponentTypeConfiguration());
        }
    }
}
