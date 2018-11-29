using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Facturacion.Entity;

namespace Facturacion.DataAccess
{
    public class DaoFacturacion : ConexionDB
    {
        
        public ResponseDocInvoiceRegistrar RegistrarFacura(string xml)
        {
            Database vDataBase = this.getDB();
            List<ResponseDocInvoiceRegistrar> respuesta = new List<ResponseDocInvoiceRegistrar>();
            using (DbCommand vDbCommand = vDataBase.GetStoredProcCommand("[dbo].[PA_DocInvoiceRegistrarWS]"))
            {
                try
                {
                    vDataBase.AddInParameter(vDbCommand, "@pXml", DbType.String, xml);
                    DataSet vDs = vDataBase.ExecuteDataSet(vDbCommand);

                    if (vDs.Tables.Count > 0)
                    {
                        respuesta = vDs.Tables[0].DataTableToList<ResponseDocInvoiceRegistrar>();
                        if (respuesta.Count > 0)
                        {
                            return respuesta[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    vDbCommand.Connection.Close();
                    vDbCommand.Connection.Dispose();
                }
            }
            return null;
        }

        public ResponseDocInvoiceRegistrar RegistrarNotaDebito(string xml)
        {
            Database vDataBase = this.getDB();
            List<ResponseDocInvoiceRegistrar> respuesta = new List<ResponseDocInvoiceRegistrar>();
            using (DbCommand vDbCommand = vDataBase.GetStoredProcCommand("[dbo].[PA_DocDebitNoteRegistrarWS]"))
            {
                try
                {
                    vDataBase.AddInParameter(vDbCommand, "@pXml", DbType.String, xml);
                    DataSet vDs = vDataBase.ExecuteDataSet(vDbCommand);

                    if (vDs.Tables.Count > 0)
                    {
                        respuesta = vDs.Tables[0].DataTableToList<ResponseDocInvoiceRegistrar>();
                        if (respuesta.Count > 0)
                        {
                            return respuesta[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    vDbCommand.Connection.Close();
                    vDbCommand.Connection.Dispose();
                }
            }
            return null;
        }

        public ResponseDocInvoiceRegistrar RegistrarNotaCredito(string xml)
        {
            Database vDataBase = this.getDB();
            List<ResponseDocInvoiceRegistrar> respuesta = new List<ResponseDocInvoiceRegistrar>();
            using (DbCommand vDbCommand = vDataBase.GetStoredProcCommand("[dbo].[PA_DocCreditNoteRegistrarWS]"))
            {
                try
                {
                    vDataBase.AddInParameter(vDbCommand, "@pXml", DbType.String, xml);
                    DataSet vDs = vDataBase.ExecuteDataSet(vDbCommand);

                    if (vDs.Tables.Count > 0)
                    {
                        respuesta = vDs.Tables[0].DataTableToList<ResponseDocInvoiceRegistrar>();
                        if (respuesta.Count > 0)
                        {
                            return respuesta[0];
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    vDbCommand.Connection.Close();
                    vDbCommand.Connection.Dispose();
                }
            }
            return null;
        }

        public List<Parametro> ConsultarParametros()
        {
            Database vDataBase = this.getDB();
            List<Parametro> parametros = new List<Parametro>();
            using (DbCommand vDbCommand = vDataBase.GetStoredProcCommand("PA_ConsultarParametros"))
            {
                try
                {
                    DataSet vDs = vDataBase.ExecuteDataSet(vDbCommand);

                    if (vDs.Tables.Count > 0)
                    {
                        parametros = vDs.Tables[0].DataTableToList<Parametro>();
                    }
                    return parametros;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    vDbCommand.Connection.Close();
                    vDbCommand.Connection.Dispose();
                }
            }
        }
        
        public bool ExisteDocumento(string nit, string documento)
        {
            Database vDataBase = this.getDB();
            List<ResponseDocInvoiceRegistrar> respuesta = new List<ResponseDocInvoiceRegistrar>();
            bool valida = false;
            using (DbCommand vDbCommand = vDataBase.GetStoredProcCommand("[dbo].[PA_ValidarDocumento]"))
            {
                try
                {
                    vDataBase.AddInParameter(vDbCommand, "@pNit", DbType.String, nit);
                    vDataBase.AddInParameter(vDbCommand, "@pDocummento", DbType.String, documento);
                    vDataBase.AddOutParameter(vDbCommand, "@pValido", DbType.Boolean, 2);
                    vDataBase.ExecuteDataSet(vDbCommand);
                    valida = Convert.ToBoolean(vDataBase.GetParameterValue(vDbCommand, "@pValido").ToString());
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    vDbCommand.Connection.Close();
                    vDbCommand.Connection.Dispose();
                }
            }
            return valida;
        }
    }
}
