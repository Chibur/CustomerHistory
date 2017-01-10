using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using CustomerPayments.Data.Interfaces;
using CustomerPayments.Domain.Entities;

namespace CustomerPayments.Data.Custom
{
    public class CustomerPaymentsContext: DbContext
    {

        public CustomerPaymentsContext(string str) : base(str) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().
                Configure(c => c.Ignore("IsDirty"));
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var history in ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory && 
                    (e.State == EntityState.Added || e.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationHistory)){
                history.DateModified = DateTime.Now;
                if (history.DateCreated == DateTime.MinValue){
                    history.DateCreated = DateTime.Now;
                }
            }
            int result = base.SaveChanges();
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory)
                .Select(e => e.Entity as IModificationHistory)
                ){
                history.IsDirty = false;
            }
            return result;
        }

     //   public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
    //    public DbSet<Transaction> Transactions { get; set; }
    }
}
