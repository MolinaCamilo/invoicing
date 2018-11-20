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
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellidos { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string TipoPersona { get; set; }
        public string TipoRegimen { get; set; }
        public string Pais { get; set; }
        public bool ObligadoFacturarElectro { get; set; }
    }
}
