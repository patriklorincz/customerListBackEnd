using CustomersList.Models.Dto;
using CustomersList.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CustomersList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult Get()
        {
            var customers = _customerService.GetCustomers();
            if(customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(Guid id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult Post([FromBody] CustomerDto customer)
        {
            if(customer.Addresses.FirstOrDefault( a => a.IsPostalAddress) == null)
            {
                return BadRequest("No postal addresss");
            }
            if (_customerService.AddCustomer(customer))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
