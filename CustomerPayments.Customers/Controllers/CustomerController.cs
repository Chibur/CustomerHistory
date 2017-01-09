using System.Web.Http;
using CustomerPayments.DataModel.Repositories;
using CustomerPayments.DataModel;
using Newtonsoft.Json;

namespace CustomerPayments.Customers.Controllers
{
    public class CustomerController: ApiController
    {
        private readonly CustomerRepository _repo = new CustomerRepository();

        public Customer Get(int id)
        {
            return _repo.GetCustomerById(id);
        }

        public void Post([FromBody] object customer)
        {
            var asCustomer = JsonConvert.DeserializeObject<Customer>(customer.ToString());

            _repo.SaveUpdatedCustomer(asCustomer);
        }

        public void Put(int id, [FromBody] Customer Customer)
        {
            _repo.SaveNewCustomer(Customer);
        }


        public void Delete(int id)
        {
            _repo.DeleteCustomer(id);
        }
    }
}