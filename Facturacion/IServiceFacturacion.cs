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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceFacturacion
    {

        [OperationContract]
        string GetData(int value);
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
        DTODocumentoSalida RegistrarFactura();
        //DTODocumentoSalida RegistrarFactura(string user, string Password, string TipoDocumentoEmpresa, string NitEmpresa, DTODocumentoEntrada entrada, string Origen);

    }
}
