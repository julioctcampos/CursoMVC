using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Domain
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Preffix { get; set; }
        public int SeatCount { get; set; }
        public string ManufacturerSite { get; set; }
        public virtual List<Component> Components { get; set; }
    }
}
