using System;

namespace CustomersList.Models
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsPostalAddress { get; set; }
        
        public virtual Customer Customer { get; set; }
    }
}
