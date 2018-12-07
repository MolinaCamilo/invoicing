using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Auditores
{
    public interface ILogable
    {
        string mensaje { get; set; }
    }
}
