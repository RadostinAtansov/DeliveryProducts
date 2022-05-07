namespace InkoOrders.Data.Model
{
    public class ProductsToDeliveryToOrderToTransactionPaymentToTransport
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }

        public int TransactionPaymentId { get; set; }
        public TransactionPayment TransactionPayment { get; set; }

        public int TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}
