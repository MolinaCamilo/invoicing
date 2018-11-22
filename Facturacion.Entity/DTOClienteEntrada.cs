using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entity
{
    public class DTOClienteEntrada
    {
        public string TipoDocumentoCliente { get; set; }
        public string DocumentoCliente { get; set; }
        public string PrimerNombre { get; set; } // puede ser null
        public string SegundoNombre { get; set; } // puede ser null
        public string Apellidos { get; set; } // puede ser null
        public string RazonSocial { get; set; } // puede ser null
        public string Direccion { get; set; } 
        public string Telefono { get; set; } // puede ser null
        public string Email { get; set; } // puede ser null
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string TipoPersona { get; set; } 
        public string TipoRegimen { get; set; }
        public string Pais { get; set; } // puede ser null
        public bool ObligadoFacturarElectro { get; set; }

        public void ValidarObligatorios(out string respuesta)
        {
            respuesta = "";
            respuesta = string.IsNullOrEmpty(this.TipoDocumentoCliente) ? "Parametro TipoDocumentoElectronico obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.DocumentoCliente) ? "Parametro Documento obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.Direccion) ? "Parametro Documento obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.Ciudad) ? "Parametro Documento obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.Departamento) ? "Parametro Documento obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.TipoPersona) ? "Parametro Documento obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
            respuesta = string.IsNullOrEmpty(this.TipoRegimen) ? "Parametro Documento obligatorio" : "";
            if (!string.IsNullOrEmpty(respuesta)) return;
        }
    }
}
