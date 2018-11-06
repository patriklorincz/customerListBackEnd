using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersList.Models.Dto
{
    public class CustomerDto
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<AddressDto> Addresses { get; set; }
    }
}
