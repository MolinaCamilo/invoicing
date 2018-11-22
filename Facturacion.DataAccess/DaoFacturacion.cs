using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Facturacion.DataAccess
{
    public class DaoFacturacion : ConexionDB
    {

        public void RegistrarFacura(string xml)
        {
            Database vDataBase = this.getDB();
            using (DbCommand vDbCommand = vDataBase.GetStoredProcCommand("[dbo].[prueba]"))
            {
                try
                {
                    vDataBase.AddInParameter(vDbCommand, "@pXml", DbType.String, xml);
                    DataSet vDs = vDataBase.ExecuteDataSet(vDbCommand);

                    if (vDs.Tables.Count > 0)
                    {
                        //vListReconocimientos = vDs.Tables[0].DataTableToList<Reconocimiento>();
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
        }
    }
}
