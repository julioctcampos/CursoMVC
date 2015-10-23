using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.Models.Component
{
    public class ComponentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Nome da Peça")]
        public string Title { get; set; }

        [DisplayName("Fabricante")]
        public string Manufacturer { get; set; }

        [DisplayName("Aeronave")]
        public string AircraftName { get; set; }
    }
}