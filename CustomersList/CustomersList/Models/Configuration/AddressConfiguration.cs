using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomersList.Models.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.AddressId);

            builder.Property(c => c.Street)
                .HasColumnName("Street")
                .HasMaxLength(100);

            builder.Property(c => c.Number)
                .HasColumnName("Number")
                .HasMaxLength(10);

            builder.Property(c => c.Postcode)
                .HasColumnName("Postcode")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.City)
                .HasColumnName("City")
                .HasMaxLength(100);

            builder.Property(c => c.Country)
                .HasColumnName("Country")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
