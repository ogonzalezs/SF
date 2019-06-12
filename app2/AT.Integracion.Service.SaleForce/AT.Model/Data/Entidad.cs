using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT.Model.Data
{
    class Entidad
    {
        public long IdEntidad { get; set; }
        public string DescripcionPrincipal { get; set; }
        public string DescripcionSecundaria { get; set; }
        public int IdTipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
    }
}
