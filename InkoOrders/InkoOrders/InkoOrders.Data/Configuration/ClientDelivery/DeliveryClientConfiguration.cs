using InkoOrders.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkoOrders.Data.Configuration
{
    public class DeliveryClientConfiguration : IEntityTypeConfiguration<DeliveryClient>
    {
        public void Configure(EntityTypeBuilder<DeliveryClient> deliveryClient)
        {
            deliveryClient.HasKey(k => new { k.DeliveryId, k.ClientId });

            deliveryClient
                          .HasOne(d => d.Client)
                          .WithMany(d => d.Deliveries)
                          .HasForeignKey(d => d.ClientId)
                          .OnDelete(DeleteBehavior.Restrict);

            deliveryClient
                          .HasOne(c => c.Delivery)
                          .WithMany(c => c.Clients)
                          .HasForeignKey(c => c.DeliveryId)
                          .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
