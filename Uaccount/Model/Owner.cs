using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uaccount.Model
{
    public class Owner
    {
        public string id { get; set; }
        public string display_name { get; set; }
        public string id_type { get; set; }
        public bool is_physical_person { get; set; }
    }
}
