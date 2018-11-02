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

        [OperationContract]
        Response RegistrarFactura(Request request);
    }
}
