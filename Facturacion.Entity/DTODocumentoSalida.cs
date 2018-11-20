using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entity
{
    public class DTODocumentoSalida
    {

        public string Nit { get; set; }
        public int IdDocumento { get; set; }
        public string Cufe { get; set; }
        public string DatosQR { get; set; }
        public string CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
        public string DetalleRespuesta { get; set; }
        public bool Resultado { get; set; }

    }
}
