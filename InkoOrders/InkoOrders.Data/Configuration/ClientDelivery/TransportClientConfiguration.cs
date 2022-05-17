using InkoOrders.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkoOrders.Data.Configuration
{
    public class TransportClientConfiguration : IEntityTypeConfiguration<TransportClient>
    {
        public void Configure(EntityTypeBuilder<TransportClient> transportClient)
        {
            transportClient.HasKey(k => new { k.ClientId, k.TransportId });

            transportClient
                            .HasOne(c => c.Client)
                            .WithMany(c => c.TransportClients)
                            .HasForeignKey(c => c.ClientId)
                            .OnDelete(DeleteBehavior.Restrict);

            transportClient
                            .HasOne(t => t.Transport)
                            .WithMany(t => t.ClientsTransport)
                            .HasForeignKey(t => t.TransportId)
                            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
