using Facturacion.Test.ServiceInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Test
{
    public class Request
    {
        public string user { get; set; }
        public string Password { get; set; }
        public string TipoDocumentoEmpresa { get; set; }
        public string NitEmpresa { get; set; }
        public DTODocumentoEntrada entrada { get; set; }
        public string Origen { get; set; }

        public Request()
        {

        }
    }
}
