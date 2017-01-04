using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    
    class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public int CustomerId { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
    }
}
