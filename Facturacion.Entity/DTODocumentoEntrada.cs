using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entity
{
    public class DTODocumentoEntrada
    {

        public string TipoDocumentoElectronico { get; set; }
        public int? Resolucion { get; set; } // puede ser null
        public string Prefijo { get; set; } // puede ser null
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public double VlrSubtotal { get; set; }
        public double VlrDescuento { get; set; }
        public double VlrImpuestos { get; set; }
        public double VlrNeto { get; set; }
        public int? DiasVence { get; set; } // puede ser null
        public double? PorInteresMora { get; set; } // puede ser null
        public string MedioPago { get; set; } // puede ser null
        public string Usuario { get; set; } // puede ser null
        public string Nota { get; set; }
        public DTOClienteEntrada Cliente { get; set; }
        public List<DTOImpuestosEntrada> Impuestos { get; set; } // puede ser null
        public List<DTOReferenciasEntrada> Referencias { get; set; }
        public string ConceptoNotaCredito { get; set; } // puede ser null
        public string ConceptoNotaDebito { get; set; } // puede ser null
        public string DocumentoFacturaReferencia { get; set; } // puede ser null

        public void ValidarObligatorios(out string respuesta)
        {
            respuesta = "";
            respuesta = string.IsNullOrEmpty(this.TipoDocumentoElectronico) ? "Parametro TipoDocumentoElectronico obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.Documento) ? "Parametro Documento obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = this.Fecha == null ? "Parametro Fecha obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = this.Hora == null ? "Parametro Hora obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = this.Nota == null ? "Parametro Nota obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = this.Cliente == null ? "Parametro Cliente obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = this.Referencias == null ? "La lista de Referencias es obligatoria" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = this.Referencias.Count() <= 0 ? "La lista de Referencias es obligatoria" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
        }
    }
}
