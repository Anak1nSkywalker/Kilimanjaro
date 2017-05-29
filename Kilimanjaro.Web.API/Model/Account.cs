using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kilimanjaro.Web.API.Model
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string CustomerId { get; set; }
        public string BankName { get; set; }
        public string CustomerName { get; set; }
        public Address CustomerAddress
        {
            get; set;
        }
    }
}
