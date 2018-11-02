using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturacion.Entity;

namespace Facturacion.Business
{
    public class FacturacionBusiness
    {

        public Response RegistrarFactura(Request request)
        {
            return new Response { codRespuesta = "123", descripcionRespuesta = "Exitoso" };
        }
    }
}
