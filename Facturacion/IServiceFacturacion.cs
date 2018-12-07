using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Facturacion.Entity;

namespace Facturacion
{
    [ServiceContract]
    public interface IServiceFacturacion
    {

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
        [OperationContract]
        //DTODocumentoSalida RegistrarFactura(string numDoc, string TipoDocumentoEmpresa, string TipoDocumentoElectronico, string docRef);
        DTODocumentoSalida RegistrarFactura(string user, string Password, string TipoDocumentoEmpresa, string NitEmpresa, DTODocumentoEntrada entrada, string Origen);

    }
}
