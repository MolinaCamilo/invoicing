using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entity
{
    public class DTOReferenciasEntrada
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Cantidad { get; set; }
        public double VlrUnitario { get; set; }
        public double? PorDescuento { get; set; }
        public double? VlrDescuento { get; set; }
        public double VlrTotal { get; set; }

    }
}
