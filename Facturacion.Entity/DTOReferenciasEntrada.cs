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
        public double? PorDescuento { get; set; } // Puede ser null
        public double? VlrDescuento { get; set; } // Puede ser null
        public double VlrTotal { get; set; }

        public void ValidarObligatorios(out string respuesta)
        {
            respuesta = "";
            respuesta = string.IsNullOrEmpty(this.Codigo) ? "Parametro Codigo obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.Descripcion) ? "Parametro Descripcion obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
        }

    }
}
