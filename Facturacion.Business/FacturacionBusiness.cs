﻿using System;
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
                DaoFacturacion dao = new DaoFacturacion();
                var parametros = dao.ConsultarParametros();
                if (ValidarDataObligatoria(out resultado, parametros))
                {
                    if (ValidarDataOpcional(out resultado, parametros))
                    {
                        var factura = Utilidades.SerializarObjetoAStringXml(this.Request);
                        dao.RegistrarFacura(factura);
                        return ArmarRespuesta("200", "Exitoso", "Exitoso", false);
                    }
                    else
                    {
                        return ArmarRespuesta("305", resultado, resultado, false);
                    }
                }
                else
                {
                    return ArmarRespuesta("305", resultado, resultado, false);
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

        private bool ValidarDataObligatoria(out string resultado, List<Parametro> parametros)
        {
            resultado = "";
            //TipoDocumentoEmpresa Obligatorio
            resultado = parametros.Where(p => p.Tipo.ToLower().Equals("tipodocumentofactura") && p.Id.Equals(this.Request.TipoDocumentoEmpresa)).FirstOrDefault() == null ? "Parametro TipoDocumentoEmpresa no valido" : "";
            if (!string.IsNullOrEmpty(resultado)) return false;
            //TipoDocumento Obligatorio
            resultado = parametros.Where(p => p.Tipo.ToLower().Equals("tipodocumentopersona") && p.Id.Equals(this.Request.entrada.Cliente.TipoDocumentoCliente)).FirstOrDefault() == null ? "Parametro TipoDocumentoCliente no valido" : "";
            if (!string.IsNullOrEmpty(resultado)) return false;
            //TipoPersona Obligatorio
            resultado = parametros.Where(p => p.Tipo.ToLower().Equals("tipopersona") && p.Id.Equals(this.Request.entrada.Cliente.TipoPersona)).FirstOrDefault() == null ? "Parametro TipoPersona no valido" : "";
            if (!string.IsNullOrEmpty(resultado)) return false;
            //TipoRegimen Obligatorio
            resultado = parametros.Where(p => p.Tipo.ToLower().Equals("tiporegimen") && p.Id.Equals(this.Request.entrada.Cliente.TipoRegimen)).FirstOrDefault() == null ? "Parametro TipoRegimen no valido" : "";
            if (!string.IsNullOrEmpty(resultado)) return false;
            //TipoImpuesto Obligatorio
            foreach(var impuesto in this.Request.entrada.Impuestos)
            {
                resultado = parametros.Where(p => p.Tipo.ToLower().Equals("tipoimpuesto") && p.Id.Equals(impuesto.TipoImpuesto)).FirstOrDefault() == null ? "Parametro TipoImpuesto no valido" : "";
                if (!string.IsNullOrEmpty(resultado)) return false;
            }
            return true;
        }

        private bool ValidarDataOpcional(out string resultado, List<Parametro> parametros)
        {
            resultado = "";
            //MedioPago No obligatorio
            if (!string.IsNullOrEmpty(this.Request.entrada.MedioPago))
            {
                resultado = parametros.Where(p => p.Tipo.ToLower().Equals("mediopago") && p.Id.Equals(this.Request.entrada.MedioPago)).FirstOrDefault() == null ? "Parametro MedioPago no valido" : "";
                if (!string.IsNullOrEmpty(resultado)) return false;
            }
            //ConceptoNotaCredito NO obligatorio
            if (!string.IsNullOrEmpty(this.Request.entrada.ConceptoNotaCredito))
            {
                resultado = parametros.Where(p => p.Tipo.ToLower().Equals("conceptonotacredito") && p.Id.Equals(this.Request.entrada.ConceptoNotaCredito)).FirstOrDefault() == null ? "Parametro ConceptoNotaCredito no valido" : "";
                if (!string.IsNullOrEmpty(resultado)) return false;
            }
            //ConceptoNotaDebito No obligatorio
            if (!string.IsNullOrEmpty(this.Request.entrada.ConceptoNotaDebito))
            {
                resultado = parametros.Where(p => p.Tipo.ToLower().Equals("conceptonotadebito") && p.Id.Equals(this.Request.entrada.ConceptoNotaDebito)).FirstOrDefault() == null ? "Parametro ConceptoNotaDebito no valido" : "";
                if (!string.IsNullOrEmpty(resultado)) return false;
            }
            //Pais No obligatorio
            if (!string.IsNullOrEmpty(this.Request.entrada.Cliente.Pais))
            {
                resultado = parametros.Where(p => p.Tipo.ToLower().Equals("pais") && p.Id.ToLower().Equals(this.Request.entrada.Cliente.Pais.ToLower())).FirstOrDefault() == null ? "Parametro Pais no valido" : "";
                if (!string.IsNullOrEmpty(resultado)) return false;
            }
            return true;
        }
    }
}
