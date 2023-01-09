using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Entities
{
    public class Employee
    {
        public int id { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String email_id { get; set; }
    }
}
