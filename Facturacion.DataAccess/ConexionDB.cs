using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Facturacion.DataAccess
{
    public class ConexionDB
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns> Database</returns>
        public Database getDB()
        {
            return new DatabaseProviderFactory().Create("InvoiceConnectionString");
        }

    }
}
