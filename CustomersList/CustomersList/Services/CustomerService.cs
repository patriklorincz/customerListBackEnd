using CustomersList.Models;
using CustomersList.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomersList.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomersListContext _dbContext;

        public CustomerService(CustomersListContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CustomerDto> GetCustomers()
        {
            var customerList = new List<CustomerDto>();

            foreach(var customer in _dbContext.Customers.Include( c => c.Addresses))
            {
                customerList.Add(MapCustomer(customer));
            }

            return customerList.Count == 0 ? null : customerList;
        }

        public CustomerDto GetCustomer(Guid customerId)
        {
            var customer = _dbContext.Customers.Include(c => c.Addresses).FirstOrDefault(c => c.CustomerId == customerId);
            return MapCustomer(customer);
        }

        public bool AddCustomer(CustomerDto newCustomer)
        {
            try
            {
                var customer = MapCustomer(newCustomer);
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private CustomerDto MapCustomer(Customer customer)
        {
            if(customer == null)
            {
                return null;
            }

            var customerDto = new CustomerDto
            {
                CustomerId = customer.CustomerId,
                Email = customer.Email,
                Name = customer.Name,
                Phone = customer.Phone,
                Website = customer.Website,
                Addresses = new List<AddressDto>()
            };

            foreach(var address in customer.Addresses){
                customerDto.Addresses.Add(new AddressDto
                {
                    AddressId = address.AddressId,
                    City = address.City,
                    Country = address.Country,
                    IsPostalAddress = address.IsPostalAddress,
                    Number = address.Number,
                    Postcode = address.Postcode,
                    Street = address.Street
                });
            }

            return customerDto;
        }

        private Customer MapCustomer(CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return null;
            }

            var customer = new Customer
            {
                CustomerId = Guid.NewGuid(),
                Email = customerDto.Email,
                Name = customerDto.Name,
                Phone = customerDto.Phone,
                Website = customerDto.Website,
                Addresses = new List<Address>()
            };

            foreach (var address in customerDto.Addresses)
            {
                customer.Addresses.Add(new Address
                {
                    AddressId = address.AddressId,
                    City = address.City,
                    Country = address.Country,
                    IsPostalAddress = address.IsPostalAddress,
                    Number = address.Number,
                    Postcode = address.Postcode,
                    Street = address.Street
                });
            }

            return customer;
        }
    }
}
