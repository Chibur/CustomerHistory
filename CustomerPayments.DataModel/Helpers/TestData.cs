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

                var Customer1 = new Customer
                {
                    FirstName = "Robin",
                    LastName = "Curry",
                    Birthdate = new DateTime(1980, 1, 1)
                };
                var Customer2 = new Customer
                {
                    FirstName = "Carry",
                    LastName = "Armstrong",
                    Birthdate = new DateTime(1981, 1, 1)
                };
                var Customer3 = new Customer
                {
                    FirstName = "Terry",
                    LastName = "Milts",
                    Birthdate = new DateTime(1982, 1, 1)
                };
                var Customer4 = new Customer
                {
                    FirstName = "Donny",
                    LastName = "Nots",
                    Birthdate = new DateTime(1983, 1, 1)
                };
                context.Customers.AddRange(new List<Customer> { Customer1, Customer2, Customer3, Customer4 });

                var Account1 = new Account
                {
                    AccountNumber = "6456545642313164",
                    Balance = 200,
                    AccountType = AccountType.Credit,
                    Customer = Customer1
                };
                var Account2 = new Account
                {
                    AccountNumber = "546544563216",
                    Balance = 452,
                    AccountType = AccountType.Credit,
                    Customer = Customer2
                };
                var Account3 = new Account
                {
                    AccountNumber = "65468765468731",
                    Balance = 445,
                    AccountType = AccountType.Credit,
                    Customer = Customer3
                };

                var Account4 = new Account
                {
                    AccountNumber = "354354324657621",
                    Balance = 455,
                    AccountType = AccountType.Credit,
                    Customer = Customer4
                };

                var Account5 = new Account
                {
                    AccountNumber = "65468765468731",
                    Balance = 2525,
                    AccountType = AccountType.Debit,
                    Customer = Customer4
                };
                context.Accounts.AddRange(new List<Account> { Account1, Account2, Account3, Account4, Account5 });

                context.Transactions.Add(new Transaction()
                {
                    Amount = 100,
                    Discription = "Test",
                    BeneficiaryAccount = "65434564324164",
                    Account = Account1
                });

                context.SaveChanges();
            //    context.Database.ExecuteSqlCommand(
            //      @"CREATE PROCEDURE GetOldCustomers
            //        AS  SELECT * FROM Customers WHERE BirthDate<='1/1/1980'");

            //    context.Database.ExecuteSqlCommand(
            //       @"CREATE PROCEDURE DeleteCustomerViaId
            //         @Id int
            //         AS
            //         DELETE from Customers Where Id = @id
            //         RETURN @@rowcount");
            }
        }
    }
}
