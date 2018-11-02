using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Facturacion.Entity;
using Facturacion.Business;

namespace Facturacion
{
    public class Service1 : IServiceFacturacion
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Response RegistrarFactura(Request request)
        {
            FacturacionBusiness facturacion = new FacturacionBusiness();
            return facturacion.RegistrarFactura(request);
        }
    }
}
