using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string sku { get; set; }
        public decimal unitprice { get; set; }
        public bool active { get; set; }
        public DateTime DateRateProduct { get; set; }

    }
}
