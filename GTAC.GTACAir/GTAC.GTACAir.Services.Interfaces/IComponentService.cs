using GTAC.GTACAir.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Services.Interfaces
{
    public interface IComponentService
    {
        void Insert(Component component);

        List<Component> Select();

        bool CanAddComponent(int aircraftId);
    }
}
