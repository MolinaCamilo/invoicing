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

        private Request Request;
        private string cufe = "";
        private int idDocumento = 0;
        private string datosQR = "";

        public FacturacionBusiness(Request _request)
        {
            this.Request = _request;
        }

        public DTODocumentoSalida ArmarRespuesta(string codRespuesta, string descRespuesta, string detRespuesta, bool resultado)
        {
            return new DTODocumentoSalida
            {
                Nit = !string.IsNullOrEmpty(this.Request.NitEmpresa) ? this.Request.NitEmpresa : "",
                Cufe = this.cufe,
                IdDocumento = idDocumento,
                DatosQR = datosQR,
                CodigoRespuesta = codRespuesta,
                DescripcionRespuesta = descRespuesta,
                DetalleRespuesta = detRespuesta,
                Resultado = resultado
            };
        }

        public DTODocumentoSalida RegistrarFactura()
        {
            string validacion = "";
            if (!autenticar(out validacion))
                return ArmarRespuesta("301", validacion, validacion, false);
            this.Request.ValidarObligatorios(out validacion);
            if (!string.IsNullOrEmpty(validacion))
                return ArmarRespuesta("305", validacion, validacion, false);


            return null;
        }

        public bool autenticar(out string respuesta)
        {
            respuesta = "";
            return true;
        }
    }
}
