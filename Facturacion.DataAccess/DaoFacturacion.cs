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
    }
}
