using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Entity
{
    public class EnumFactura
    {

        public enum TipoFactura
        {
            [StringValue("FV")]
            FacturaVenta = 1,
            [StringValue("NC")]
            NotaCredito = 2,
            [StringValue("ND")]
            NotaDebito = 3,
        }

        public static string GetStringValue(Enum enumerador)
        {
            string value = null;
            var type = enumerador.GetType();
            var fi = type.GetField(enumerador.ToString());
            var attr = fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];
            if(attr.Length > 0)
            {
                value = attr[0].Value;
            }
            return value;
        }

        public class StringValue: Attribute
        {
            public string Value { get;  private set; }

            public StringValue(string value)
            {
                Value = value;
            }

        }
    }
}
