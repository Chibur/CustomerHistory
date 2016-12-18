using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerHistory.Backend.Models
{
    public class CustomerAccounts
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public decimal balance { get; set; }
    }
}