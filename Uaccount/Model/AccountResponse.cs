using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uaccount.Model
{
    public class AccountResponse
    {
        public string id { get; set; }
        public string bank { get; set; }
        public string cbu { get; set; }
        public string type { get; set; }
        public double amount { get; set; }
    }
}
