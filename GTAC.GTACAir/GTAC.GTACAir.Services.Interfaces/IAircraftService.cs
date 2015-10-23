using GTAC.GTACAir.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Services.Interfaces
{
    public interface IAircraftService
    {
        List<Aircraft> Select();
    }
}
