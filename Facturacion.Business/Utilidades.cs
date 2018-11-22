using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Facturacion.Business
{
    public class Utilidades
    {

        public static string SerializarObjetoAStringXml<T>(T objetoSerializable)
        {
            try
            {
                XmlSerializer serializaXml = new XmlSerializer(objetoSerializable.GetType());
                string xmlSerializado = string.Empty;

                using (var flujoString = new StringWriter())
                {
                    using (var flujoXml = XmlWriter.Create(flujoString))
                    {
                        serializaXml.Serialize(flujoXml, objetoSerializable);
                        xmlSerializado = flujoString.ToString();
                    }
                }

                return xmlSerializado;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }
    }
}
