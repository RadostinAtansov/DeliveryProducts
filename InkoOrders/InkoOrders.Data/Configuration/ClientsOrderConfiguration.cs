using InkoOrders.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkoOrders.Data
{
    public class ClientsOrderConfiguration : IEntityTypeConfiguration<ClientsOrder>
    {
        public void Configure(EntityTypeBuilder<ClientsOrder> clientsOrder)
        {


            clientsOrder.HasKey(k => new { k.OrderId, k.ClientId });

            clientsOrder
                        .HasOne(c => c.Client)
                        .WithMany(c => c.Orders)
                        .HasForeignKey(c => c.ClientId)
                        .OnDelete(DeleteBehavior.Restrict);

            clientsOrder
                        .HasOne(o => o.Order)
                        .WithMany(c => c.Clients)
                        .HasForeignKey(o => o.OrderId)
                        .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
