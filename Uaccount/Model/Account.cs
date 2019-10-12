using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uaccount.Model
{
    public class Account
    {
        public string id { get; set; }
        public string label { get; set; }
        public string number { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public List<Owner> owners { get; set; }
        public Balance balance { get; set; }
        public string bank_id { get; set; }
        public AccountRouting acoount_routing { get; set; }
    }
}
