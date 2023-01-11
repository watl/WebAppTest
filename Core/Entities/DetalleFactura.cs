using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DetalleFactura
    {
        public int id { get; set; }
        public string idproducto { get; set; }
        public string idfactura { get; set; }
        public int cantidad { get; set; }
    }
}
