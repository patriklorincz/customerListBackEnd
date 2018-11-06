using System;
using System.Collections.Generic;

namespace CustomersList.Models
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
