using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Auditores
{
    public class MensajeLogable: ILogable
    {

        public string Mensaje { get; set; }
        public string mensaje
        {
            get
            {
                return Mensaje;
            }
            set
            {
                Mensaje = value;
            }
        }
    }
}
