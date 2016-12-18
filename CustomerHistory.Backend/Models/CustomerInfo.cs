using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerHistory.Backend.Models
{
    public class CustomerInfo
    {
        public CustomerInfo(int id)
        {
            this.id = id;
            this.firstName = "name";
            this.lastName = "Last name";
            this.birthDate = DateTime.Now;
        }

        public int id { get; set;}
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
    }
}