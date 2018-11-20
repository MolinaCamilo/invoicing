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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Password"></param>
        /// <param name="TipoDocumentoEmpresa"></param>
        /// <param name="NitEmpresa"></param>
        /// <param name="entrada"></param>
        /// <param name="Origen"></param>
        /// <returns></returns>
        public DTODocumentoSalida RegistrarFactura(string user, string Password, string TipoDocumentoEmpresa, string NitEmpresa, DTODocumentoEntrada entrada, string Origen)
        {
            Request request = new Request(user, Password,TipoDocumentoEmpresa, NitEmpresa, entrada, Origen);
            return new FacturacionBusiness(request).RegistrarFactura();
        }

        
    }
}
