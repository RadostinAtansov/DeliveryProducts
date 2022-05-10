using InkoOrders.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkoOrders.Data.Configuration
{
    public class DocumentsTransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> transport)
        {
            transport
                      .HasMany<Document>(d => d.Documents)
                      .WithOne(t => t.Transport)
                      .HasForeignKey(k => k.TransportId)
                      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
