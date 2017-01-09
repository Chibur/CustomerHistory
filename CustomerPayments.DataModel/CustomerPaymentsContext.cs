using System.Data.Entity;

namespace CustomerPayments.DataModel
{
    public class CustomerPaymentsContext: DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
