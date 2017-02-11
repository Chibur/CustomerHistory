using AutoMapper;
using CustomerPayments.Domain.Entities;
using CustomerPayments.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPayments.Data.Mappers
{
    public class AutoMapperFactory
    {
        public static IMapper Create()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //forth
                cfg.CreateMap<Account, AccountDTO>();
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<Transaction, TransactionDTO>();

                //back
                cfg.CreateMap<AccountDTO, Account>();
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<TransactionDTO, Transaction>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }   
    }
}
