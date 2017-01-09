using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CustomerPayments.DTO
{
    class DataAccessLayer
    {
        private OdbcConnection _connection;
        private OdbcDataAdapter _adapter;

        public DataAccessLayer()
        {
            _connection = new OdbcConnection();
            _adapter = new OdbcDataAdapter();
            _connection.ConnectionString = "Driver={SQL Server}; Server={}; Database=CustomerPayments.Database; Integrated Security = False"; 
        }

        public Customer GetCustomer(int Id)
        {
            try
            {
                _connection.Open();
                OdbcCommand command = _connection.CreateCommand();
                command.CommandText = "SQL querry to get from db";
                DataSet data = new DataSet();
                _adapter.SelectCommand = command;
                _adapter.Fill(data, "Table name");

                DataTable dt = data.Tables[0];
                // map all the fields
                //string id = dt.Rows[0]["ID"].ToString();
                return new Customer();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _connection.Close();
            }
            
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                _connection.Open();
                OdbcCommand command = _connection.CreateCommand();
                command.CommandText = "Querry string to modify db";
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }  
        }
    }
}
