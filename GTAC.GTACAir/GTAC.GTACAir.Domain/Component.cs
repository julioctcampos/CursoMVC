using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Domain
{
    /// <summary>
    ///     Classe que representa as peças do avião
    /// </summary>
    public class Component
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }

        public virtual Aircraft Aircraft { get; set; }
        public int AircraftId { get; set; }
    }
}
