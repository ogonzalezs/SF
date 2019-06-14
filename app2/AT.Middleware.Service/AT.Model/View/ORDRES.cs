using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.View
{
    public class ORDRES
    {
        public string Code { get; set; }
        public string U_Status { get; set; }
        public DateTime U_FechaCrea { get; set; }
        public DateTime U_HoraCrea { get; set; }
        public DateTime? U_FechaUpd { get; set; }
        public DateTime? U_HoraUpd { get; set; }
    }
}