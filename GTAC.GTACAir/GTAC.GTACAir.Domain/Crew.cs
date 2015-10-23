using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Domain
{
    public class Crew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AnacCode { get; set; }
        public string CompanyNumber { get; set; }
        public bool Active { get; set; }
        public string Nickname { get; set; }
    }
}
