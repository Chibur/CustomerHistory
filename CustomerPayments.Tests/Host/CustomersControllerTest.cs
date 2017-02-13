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

namespace CustomerPayments.Tests.Host
{
    [TestFixture]
    public class CustomersControllerTest
    {
        [Test]
        public void GetReturnsCustomers()
        {
            //Arrange
            var repository = new Mock<IGenericRepository<Customer>>().Object;
            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<Customer, CustomerDTO>(It.IsAny<Customer>())).Returns(new CustomerDTO());
            var controller = new CustomersController(repository, mapper.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //Act
            var response = controller.Get(1);
            //Assert

        }
    }
}
