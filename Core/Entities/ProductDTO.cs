using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public decimal pricecordprod { get; set; }
        public decimal priceusdprod { get; set; }
        public decimal rateday { get; set; }
    }
}
