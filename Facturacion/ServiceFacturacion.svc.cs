using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Facturacion.Entity;
using Facturacion.Business;

namespace Facturacion
{
    public class Service1 : IServiceFacturacion
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

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
        //public DTODocumentoSalida RegistrarFactura(string user, string Password, string TipoDocumentoEmpresa, string NitEmpresa, DTODocumentoEntrada entrada, string Origen)
        public DTODocumentoSalida RegistrarFactura()
        {
            string user = "camilo";
            string Password = "paswordcamilo";
            string TipoDocumentoEmpresa = "1";
            string NitEmpresa = "nitEmpresa";
            DTOClienteEntrada cliente = new DTOClienteEntrada
            {
                TipoDocumentoCliente = "13",
                DocumentoCliente = "1051954972",
                PrimerNombre = "José",
                SegundoNombre = "Camilo",
                Apellidos = "Molina Piratova",
                RazonSocial = "Peresona Natural",
                Direccion = "Cra 50",
                Telefono = "3003877549",
                Email = "molina.josecamilo@gmail.com",
                Ciudad = "Tunja",
                Departamento = "Boyaca",
                TipoPersona = "1",
                TipoRegimen = "0",
                Pais = "co",
                ObligadoFacturarElectro = false
            };

            DTOImpuestosEntrada dtoImp1 = new DTOImpuestosEntrada
            {
                TipoImpuesto = "01",
                PorTarifa = 10,
                VlrBase = 12000,
                VlrImpuesto = 10000
            };
            DTOImpuestosEntrada dtoImp2 = new DTOImpuestosEntrada
            {
                TipoImpuesto = "02",
                PorTarifa = 20,
                VlrBase = 22000,
                VlrImpuesto = 20000
            };
            List<DTOImpuestosEntrada> listImpuesto = new List<DTOImpuestosEntrada>();
            listImpuesto.Add(dtoImp1);
            listImpuesto.Add(dtoImp2);

            DTOReferenciasEntrada ref1 = new DTOReferenciasEntrada
            {
                Codigo = "0001",
                Descripcion = "desc 1",
                Cantidad = 30,
                VlrUnitario = 1000,
                PorDescuento = 0, //puede ser null
                VlrDescuento = 0, //puede ser null
                VlrTotal = 30000
            };
            DTOReferenciasEntrada ref2 = new DTOReferenciasEntrada
            {
                Codigo = "0001",
                Descripcion = "Desc 2",
                Cantidad = 30,
                VlrUnitario = 1000,
                PorDescuento = 0, //puede ser null
                VlrDescuento = 0, //puede ser null
                VlrTotal = 30000
            };
            List<DTOReferenciasEntrada> referencias = new List<DTOReferenciasEntrada>();
            referencias.Add(ref1);
            referencias.Add(ref2);
            DTODocumentoEntrada entrada = new DTODocumentoEntrada
            {
                TipoDocumentoElectronico = "tipDocElect",
                Resolucion = 1212, //Puede ser null
                Prefijo = "Pref",
                Documento = "Doc",
                Fecha = DateTime.Now,
                Hora = DateTime.Now,
                VlrSubtotal = 12000,
                VlrDescuento = 0.0,
                VlrImpuestos = 1.0,
                VlrNeto = 10000,
                DiasVence = 3, //Puede ser null
                PorInteresMora = 0.0, //puede ser null
                MedioPago = null,
                Usuario = "User1",
                Nota = "Nota",
                Cliente = cliente,
                Impuestos = listImpuesto,
                Referencias = referencias,
                ConceptoNotaCredito = "2",
                ConceptoNotaDebito = "1",
                DocumentoFacturaReferencia = "768",
            };
            string Origen = "prueba";
            Request request = new Request(user, Password, TipoDocumentoEmpresa, NitEmpresa, entrada, Origen);
            return new FacturacionBusiness(request).RegistrarFactura();
        }


    }
}
