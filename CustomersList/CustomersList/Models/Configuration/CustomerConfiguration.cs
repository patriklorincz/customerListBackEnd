using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomersList.Models.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Website)
                .HasColumnName("Website")
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .HasMaxLength(100);

            builder.Property(c => c.Phone)
                .HasColumnName("Phone")
                .IsRequired()
                .HasMaxLength(15);
        }
    }
}
