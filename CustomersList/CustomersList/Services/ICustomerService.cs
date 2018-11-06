using CustomersList.Models.Dto;
using System;
using System.Collections.Generic;

namespace CustomersList.Services
{
    public interface ICustomerService
    {
        List<CustomerDto> GetCustomers();
        CustomerDto GetCustomer(Guid customerId);
        bool AddCustomer(CustomerDto newCustomer);
    }
}
