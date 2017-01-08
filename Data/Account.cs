﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.Data
{
    
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public byte[] DateCreated { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
        public int CustomerId { get; set; }
    }
}
