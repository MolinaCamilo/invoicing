using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization; 

namespace Facturacion.Test
{
    public class ConsumoServicio
    {

        private string xml;

        public ConsumoServicio(string Pxml)
        {
            this.xml = Pxml;
        }

        public ServiceInvoice.DTODocumentoSalida RegistarFactura()
        {
            ServiceInvoice.ServiceFacturacionClient servicio = new ServiceInvoice.ServiceFacturacionClient();
            Request request = new Request();
            var obj = DeserializarStringXmlAObjeto(this.xml, request);
            return servicio.RegistrarFactura(obj.user, obj.Password, obj.TipoDocumentoEmpresa, obj.NitEmpresa, obj.entrada, obj.Origen);
        }

        private static T DeserializarStringXmlAObjeto<T>(string stringXml, T ClaseObjeto)
        {
            try
            {
                StringReader lectorString = new StringReader(stringXml);
                XmlSerializer serializador = new XmlSerializer(ClaseObjeto.GetType());
                var objetoDeserializado = serializador.Deserialize(lectorString);

                return (T)Convert.ChangeType(objetoDeserializado, ClaseObjeto.GetType());
            }
            catch (Exception exc)
            {
                return (T)Convert.ChangeType(exc, exc.GetType());
            }
        }
    }
}
