using InkoOrders.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkoOrders.Data.Configuration
{
    public class ProductsToDeliveryToOrderToTransactionPaymentToTransportConfiguration : IEntityTypeConfiguration<ProductsToDeliveryToOrderToTransactionPaymentToTransport>
    {
        public void Configure(EntityTypeBuilder<ProductsToDeliveryToOrderToTransactionPaymentToTransport> builder)
        {
            builder.HasKey(k => new { k.OrderId, k.DeliveryId, k.ClientId, k.TransactionPaymentId, k.TransportId });

            //1
            builder
                    .HasOne(p => p.Product)
                    .WithMany(p => p.ProDelOrdTranPayTran)
                    .HasForeignKey(p => p.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder
                    .HasOne(p => p.Client)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
            //2
            builder
                    .HasOne(p => p.Product)
                    .WithMany(p => p.ProDelOrdTranPayTran)
                    .HasForeignKey(p => p.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder
                    .HasOne(p => p.Transport)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.TransportId)
                    .OnDelete(DeleteBehavior.Restrict);
            //3
            builder
                    .HasOne(p => p.Product)
                    .WithMany(p => p.ProDelOrdTranPayTran)
                    .HasForeignKey(p => p.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder
                    .HasOne(p => p.TransactionPayment)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.TransactionPaymentId)
                    .OnDelete(DeleteBehavior.Restrict);
            //4
            builder
                    .HasOne(p => p.Product)
                    .WithMany(p => p.ProDelOrdTranPayTran)
                    .HasForeignKey(p => p.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder
                    .HasOne(p => p.Delivery)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.DeliveryId)
                    .OnDelete(DeleteBehavior.Restrict);
            //5
            builder
                    .HasOne(p => p.Product)
                    .WithMany(p => p.ProDelOrdTranPayTran)
                    .HasForeignKey(p => p.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder
                    .HasOne(p => p.Order)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
