using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Price
    {
        public int id { get; set; }
        public int idproduct { get; set; }
        public int idrate { get; set; }
        public decimal pricecord { get; set; }
        public decimal priceusd { get; set; }


    }
}
