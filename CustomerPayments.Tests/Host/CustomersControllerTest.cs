using CustomerPayments.Domain.Entities;
using CustomerPayments.Domain.Interfaces;
using CustomerPayments.Host.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CustomerPayments.DTO;
using Ploeh.AutoFixture;
using System.Web.Http;
using System.Web.Http.Results;

namespace CustomerPayments.Tests.Host
{
    [TestFixture]
    public class CustomersControllerTest
    {
        // TODO maybe it is possible to put fixture and  Mock one place and not to reinit it every time
        [Test]
        public void GetReturnsCustomer()
        {
            //Arrange
            Fixture fixture = new Fixture();
            var id = fixture.Create<int>();
            Customer customer = fixture.Create<Customer>();

            var repository = new Mock<IGenericRepository<Customer>>();
            repository.Setup(c => c.FindById(id)).Returns(customer);

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<Customer, CustomerDTO>(It.IsAny<Customer>())).Returns(new CustomerDTO());
            var customerDTO = mapper.Object.Map<CustomerDTO>(customer);

            var controller = new CustomersController(repository.Object, mapper.Object);

            //Act
            IHttpActionResult response = controller.Get(id);
            var responseResult = response as OkNegotiatedContentResult<CustomerDTO>;
            //Assert
            Assert.That(responseResult.Content, Is.EqualTo(customerDTO));
        }
    }
}
