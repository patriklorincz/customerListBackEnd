using CustomersList.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CustomersList.Models
{
    public class CustomersListContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public CustomersListContext(DbContextOptions<CustomersListContext> options)
            : base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
        }
    }
}
