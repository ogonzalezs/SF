using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.Data
{
    public class Enlace
    {
        public int Id { get; set; }
        public string Table { get; set; }
        public DateTime Fecha { get; set; }
        public string FileName { get; set; }
        public long IdEmpresas { get; set; }
    }
}
