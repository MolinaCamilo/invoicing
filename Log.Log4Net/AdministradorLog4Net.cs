using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.Auditores;

namespace Log.Log4Net
{
    public class AdministradorLog4Net
    {
        public static IFacturacionAuditor GetAuditor(Type type)
        {
            return new FacturacioLog4Net(type);
        }

    }
}
