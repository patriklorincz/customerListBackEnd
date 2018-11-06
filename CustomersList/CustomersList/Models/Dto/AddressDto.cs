using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersList.Models.Dto
{
    public class AddressDto
    {
        public Guid AddressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsPostalAddress { get; set; }
    }
}
