using InkoOrders.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkoOrders.Data.Configuration
{
    public class ClientsTransactionConfiguration : IEntityTypeConfiguration<ClientsTransaction>
    {
        public void Configure(EntityTypeBuilder<ClientsTransaction> clientsTransaction)
        {
            clientsTransaction.HasKey(k => new { k.ClientId, k.TrasactionPaymentId });

            clientsTransaction
                               .HasOne(x => x.Client)
                               .WithMany(x => x.TransactionPayments)
                               .HasForeignKey(k => k.ClientId)
                               .OnDelete(DeleteBehavior.Restrict);

            clientsTransaction
                               .HasOne(t => t.TransactionPayment)
                               .WithMany(c => c.Clients)
                               .HasForeignKey(k => k.TrasactionPaymentId)
                               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
