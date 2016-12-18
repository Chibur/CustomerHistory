using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerHistory.Backend.Models;

namespace CustomerHistory.Backend.DataAccessLayer
{
    public class CustomerInfoAccess
    {
        public CustomerInfoAccess() { }
        
        public CustomerInfo read(int id)
        {
            CustomerInfo info = new CustomerInfo(id);
            return info;
        }   
    }
}