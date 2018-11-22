using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturacion.DataAccess;
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
            try
            {
                string validacion = "";
                if (!autenticar(out validacion))
                    return ArmarRespuesta("301", validacion, validacion, false);
                this.Request.ValidarObligatorios(out validacion);
                if (!string.IsNullOrEmpty(validacion))
                    return ArmarRespuesta("305", validacion, validacion, false);
                this.Request.entrada.ValidarObligatorios(out validacion);
                if (!string.IsNullOrEmpty(validacion))
                    return ArmarRespuesta("305", validacion, validacion, false);
                this.Request.entrada.Cliente.ValidarObligatorios(out validacion);
                if (!string.IsNullOrEmpty(validacion))
                    return ArmarRespuesta("305", validacion, validacion, false);
                if (this.Request.entrada.Impuestos != null)
                {
                    foreach (var impuesto in this.Request.entrada.Impuestos)
                    {
                        impuesto.ValidarObligatorios(out validacion);
                        if (!string.IsNullOrEmpty(validacion))
                            return ArmarRespuesta("305", validacion, validacion, false);
                    }
                }
                foreach (var referencia in this.Request.entrada.Referencias)
                {
                    referencia.ValidarObligatorios(out validacion);
                    if (!string.IsNullOrEmpty(validacion))
                        return ArmarRespuesta("305", validacion, validacion, false);
                }
                string resultado = "";
                if (ValidarData(out resultado))
                {
                    var factura = Utilidades.SerializarObjetoAStringXml(this.Request);
                    DaoFacturacion dao = new DaoFacturacion();
                    dao.RegistrarFacura(factura);
                    return ArmarRespuesta("200", "Exitoso", "Exitoso", false);
                }
                else
                {
                    return ArmarRespuesta("305", "Datos Inconsistentes o incompletos", "Datos Inconsistentes o incompletos", false);
                }
            }
            catch (Exception ex)
            {
                return ArmarRespuesta("305", "Datos Inconsistentes o incompletos", "Datos Inconsistentes o incompletos", false);
            }
        }

        public bool autenticar(out string respuesta)
        {
            respuesta = "";
            return true;
        }

        private bool ValidarData(out string resultado)
        {
            resultado = "";
            return true;
        }
    }
}
