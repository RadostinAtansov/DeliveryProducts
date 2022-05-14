using InkoOrders.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkoOrders.Data.Configuration
{
    public class TransportAndTransactionPaymentConfiguration : IEntityTypeConfiguration<TransportAndTransactionPayment>
    {
        public void Configure(EntityTypeBuilder<TransportAndTransactionPayment> transportAndTransactionPayment)
        {
            transportAndTransactionPayment.HasKey(k => new { k.TransportId, k.TransactionPaymentsId });

            transportAndTransactionPayment
                                           .HasOne(t => t.Transport)
                                           .WithMany(t => t.TransactionPayments)
                                           .HasForeignKey(t => t.TransportId)
                                           .OnDelete(DeleteBehavior.Restrict);

            transportAndTransactionPayment
                                           .HasOne(p => p.TransactionPayment)
                                           .WithMany(p => p.Transports)
                                           .HasForeignKey(p => p.TransactionPaymentsId)
                                           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
