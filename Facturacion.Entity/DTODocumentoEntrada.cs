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
        public int? Resolucion { get; set; }
        public string Prefijo { get; set; }
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public double VlrSubtotal { get; set; }
        public double VlrDescuento { get; set; }
        public double VlrImpuestos { get; set; }
        public double VlrNeto { get; set; }
        public int? DiasVence { get; set; }
        public double? PorInteresMora { get; set; }
        public string MedioPago { get; set; }
        public string Usuario { get; set; }
        public string Nota { get; set; }
        public DTOClienteEntrada Cliente { get; set; }
        public List<DTOImpuestosEntrada> Impuestos { get; set; }
        public List<DTOReferenciasEntrada> Referencias { get; set; }
        public string ConceptoNotaCredito { get; set; }
        public string ConceptoNotaDebito { get; set; }
        public string DocumentoFacturaReferencia { get; set; }

    }
}
