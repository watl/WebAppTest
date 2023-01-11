using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FacturaDTO
    {
        public int id { get; set; }
        public int idcliente { get; set; }
        public int numerofactura { get; set; }
        public DateTime fechafactura { get; set; }
        public decimal iva { get; set; }
        public decimal subtotal { get; set; }
        public decimal total { get; set; }
        public List<DetalleFactura> Detalles { get; set; }
    }
}
