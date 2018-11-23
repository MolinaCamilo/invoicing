using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.DataAccess
{
    public static class DataTableUtil
    {

        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (DataRow row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            if (table.Columns.Contains(prop.Name))
                            {
                                PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);

                                Type t = propertyInfo.PropertyType;
                                t = Nullable.GetUnderlyingType(t) ?? t;

                                if (!row.IsNull(prop.Name))
                                {
                                    propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], t), null);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error al convertir dato en DataTableToList. " + ex.Message);
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recorrer el DataTable en DataTableToList. " + ex.Message);
            }
        }

    }
}
