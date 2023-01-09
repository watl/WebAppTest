using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public DateTime DateRate { get; set; }
        public double RateCord { get; set; }
        public double RateUsd { get; set; }

    }
}
