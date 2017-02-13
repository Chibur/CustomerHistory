using CustomerPayments.Data.Repository;
using CustomerPayments.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.Tests.Data
{
    [TestFixture]
    public class GenericRepositoryIntegrationTests
    {
    //    private StringBuilder _logBuilder = new StringBuilder();
    //    private string _log;
    //    private CustomerPaymentsContext _context;
    //    private GenericRepository<Customer> _customerRepository;

    //    public GenericRepositoryIntegrationTests()
    //    {
    //        Database.SetInitializer(new NullDatabaseInitializer<CustomerPaymentsContext>());
    //        _context = new CustomerPaymentsContext();
    //        _customerRepository = new GenericRepository<Customer>(_context);
    //        SetupLogging();
    //    }

    //    [Test]
    //    public void CanFindByCustomerById()
    //    {
    //        _customerRepository.FindById(1);
    //        WriteLog();
    //        Assert.IsTrue(_log.Contains("FROM [Customers]");
    //    }

    //    [Test]
    //    public void CanFindByAccountById()
    //    {
    //        new GenericRepository<Account>(_context).FindById(1);
    //        WriteLog();
    //        Assert.IsTrue(_log.Contains("FROM [Accounts]"));
    //    }

    //    [Test]
    //    public void CanFindByTransactionById()
    //    {
    //        new GenericRepository<Transaction>(_context).FindById(1);
    //        WriteLog();
    //        Assert.IsTrue(_log.Contains("FROM [Transactions]"));
    //    }

    //    [Test]
    //    public void NoTrackingQueriesDoNotCacheObjects()
    //    {
    //        _customerRepository.FindAll();
    //        Assert.AreEqual(0, _context.ChangeTracker.Entries().Count());
    //    }

    //    //revise
    //    [Test]
    //    public void CanQueryWithSinglePredicate()
    //    {
    //        _customerRepository.FindBy(c => c.LastName.StartsWith("C"));
    //        WriteLog();
    //        Assert.IsTrue(_log.Contains("'C%'"));
    //    }

    //    [Test]
    //    public void CanQueryWithDualPredicate()
    //    {
    //        var date = new DateTime(1979, 1, 1);
    //        _customerRepository
    //           .FindBy(c => c.LastName.StartsWith("C") && c.Birthdate>= date);
    //        WriteLog();
    //        Assert.IsTrue(_log.Contains("'C%'") && _log.Contains("1/1/1979"));
    //    }
    //    [Test]
    //    public void CanQueryWithComplexRelatedPredicate()
    //    {
    //        var date = new DateTime(1979, 1, 1);
    //        _customerRepository
    //           .FindBy(c => c.LastName.StartsWith("C") && c.Birthdate >= date
    //                                                   && c.Transactions.Any());
    //        WriteLog();
    //        Assert.IsTrue(_log.Contains("'C%'") && _log.Contains("1/1/1979") && _log.Contains("Transactions"));
    //    }
    //    [Test]
    //    public void ComposedOnAllListExecutedInMemory()
    //    {
    //        _customerRepository.FindAll().Where(c => c.FirstName == "Daniel").ToList();
    //        WriteLog();
    //        Assert.IsFalse(_log.Contains("Daniel"));
    //    }

    //    [Test]
    //    public void CanInsertCustomerWithoutOptionalEmail()
    //    {
    //        var customer = new Customer { Birthdate = DateTime.Today, FirstName = "River", LastName = "Tam", LoginId = "123456", PhoneNumber = "865423568"  };
    //        _customerRepository.Insert(customer);
    //        WriteLog();
    //        Assert.AreNotEqual(0, customer.Id);
    //    }

    //    [Test]
    //    public void CanInsertCustomerEmail()
    //    {
    //        var customer = new Customer
    //        {
    //            Birthdate = DateTime.Today,
    //            FirstName = "Sampson",
    //            LastName = "Flynn",
    //            LoginId = "123457",
    //            PhoneNumber = "865423569",
    //            EmailAddress = "a@m.lt"
    //        };
    //        _customerRepository.Insert(customer);
    //        WriteLog();
    //        Assert.AreNotEqual(0, customer.Id);
    //        Assert.NotNull(customer.EmailAddress);
    //    }
    //    private void WriteLog()
    //    {
    //        Debug.WriteLine(_log);
    //    }

    //    private void SetupLogging()
    //    {
    //        _context.Database.Log = BuildLogString;
    //    }

    //    private void BuildLogString(string message)
    //    {
    //        _logBuilder.Append(message);
    //        _log = _logBuilder.ToString();
    //    }
    //}
}
