using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entity
{
    public class DTOImpuestosEntrada
    {

        public string TipoImpuesto { get; set; }
        public double PorTarifa { get; set; }
        public double VlrBase { get; set; }
        public double VlrImpuesto { get; set; }
    }
}
