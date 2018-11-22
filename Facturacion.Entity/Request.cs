using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entity
{
    public class Request
    {
        public string user { get; set; }
        public string Password { get; set; }
        public string TipoDocumentoEmpresa { get; set; }
        public string NitEmpresa { get; set; }
        public DTODocumentoEntrada entrada { get; set; }
        public string Origen { get; set; }

        public Request()
        {

        }

        public Request(string user, string password, string tipoDocumentoEmpresa, string nitEmpresa, DTODocumentoEntrada entrada, string origen)
        {
            this.user = user;
            this.Password = password;
            this.TipoDocumentoEmpresa = tipoDocumentoEmpresa;
            this.NitEmpresa = nitEmpresa;
            this.entrada = entrada;
            this.Origen = origen;
        }

        public void ValidarObligatorios(out string respuesta)
        {
            respuesta = "";
            respuesta = string.IsNullOrEmpty(this.user) ? "Parametro user obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.Password) ? "Parametro Password obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.TipoDocumentoEmpresa) ? "Parametro TipoDocumentoEmpresa obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.NitEmpresa) ? "Parametro NitEmpresa obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.Origen) ? "Parametro Origen obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = this.entrada == null ? "Parametro DTODocumentoEntrada obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
        }
    }
}
