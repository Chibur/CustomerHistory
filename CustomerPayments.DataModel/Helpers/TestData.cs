using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.DataModel.Helpers
{
    public class TestData
    {
        public static void NewDbWithSeed()
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<CustomerPaymentsContext>());
            using (var context = new CustomerPaymentsContext())
            {
                if (context.Customers.Any())
                {
                    return;
                }
                context.Transactions.Add(new Transaction()
                {
                    Amount = 100,
                    Discription = "Test",
                    BeneficiaryAccount = "65434564324164",
                    Account = context.Accounts.FirstOrDefault()
                });

                context.Accounts.Add(new Account
                {
                    AccountNumber = "6456545642313164",
                    Balance = 200,
                    AccountType = AccountType.Credit,
                    Transacions = context.Transactions.ToList()
                });
                context.Accounts.Add(new Account
                {
                    AccountNumber = "546544563216",
                    Balance = 200,
                    AccountType = AccountType.Credit,
                    Transacions = context.Transactions.ToList()
                });
                context.Accounts.Add(new Account
                {
                    AccountNumber = "65468765468731",
                    Balance = 200,
                    AccountType = AccountType.Credit,
                    Transacions = context.Transactions.ToList()
                });

                var j = new Customer
                {
                    FirstName = "Robin",
                    LastName = "Curry",
                    Birthdate = new DateTime(1980, 1, 1),
                    Accounts = context.Accounts.ToList()
                };
                var s = new Customer
                {
                    FirstName = "Carry",
                    LastName = "Armstrong",
                    Birthdate = new DateTime(1981, 1, 1),
                    Accounts = context.Accounts.ToList()
                };
                var l = new Customer
                {
                    FirstName = "Terry",
                    LastName = "Milts",
                    Birthdate = new DateTime(1982, 1, 1),
                    Accounts = context.Accounts.ToList()
                };
                var r = new Customer
                {
                    FirstName = "Donny",
                    LastName = "Nots",
                    Birthdate = new DateTime(1983, 1, 1),
                    Accounts = context.Accounts.ToList()
                };
                context.Customers.AddRange(new List<Customer> { j, s, l, r });

                context.SaveChanges();
                context.Database.ExecuteSqlCommand(
                  @"CREATE PROCEDURE GetOldCustomers
                    AS  SELECT * FROM Customers WHERE BirthDate<='1/1/1980'");

                context.Database.ExecuteSqlCommand(
                   @"CREATE PROCEDURE DeleteCustomerViaId
                     @Id int
                     AS
                     DELETE from Customers Where Id = @id
                     RETURN @@rowcount");
            }
        }
    }
}
