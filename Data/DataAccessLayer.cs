using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CustomerPayments.Data
{
    class DataAccessLayer
    {
        SqlConnection _myConnection;

        public DataAccessLayer()
        {
            _myConnection = new SqlConnection(@"user id=edgaras;" +
                                       @"password=password;server=(localdb)\ProjectsV13;" +
                                       @"Trusted_Connection=yes;" +
                                       @"database=CustomerPayments.Database; " +
                                       @"connection timeout=30");
        }

        //public CustomerAccounts[] GetAccounts (int customerId)
        //{

        //}

        //public CustomerInfo GetInfo(int customerId)
        //{

        //}

        //public bool CommitTransaction (CustomerTransaction transaction)
        //{

        //} 
    }
}
