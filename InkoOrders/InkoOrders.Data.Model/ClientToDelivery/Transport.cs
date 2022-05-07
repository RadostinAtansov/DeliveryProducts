using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model
{
    using static DataValidation;

    public class Transport
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TransportFromCompany)]
        public string FromCompany { get; set; }

        public DateTime DatetimeOrdered { get; set; }

        [Required]
        [MaxLength(TransportToClient)]
        public string ToClient { get; set; }

        public DateTime DatetimeArrive { get; set; }

        public ICollection<Document> Documents { get; set; } = new HashSet<Document>();

        public ICollection<TransportAndTransactionPayment> TransactionPayments { get; set; } = new HashSet<TransportAndTransactionPayment>();

        public ICollection<Product> ProductsOrdered { get; set; }

        public ICollection<DeliveryClient> ClientsDelivery { get; set; } = new HashSet<DeliveryClient>();

        public ICollection<TransportClient> ClientsTransport { get; set; } = new HashSet<TransportClient>();

        public ICollection<ProductsToDeliveryToOrderToTransactionPaymentToTransport> Products { get; set; } = new HashSet<ProductsToDeliveryToOrderToTransactionPaymentToTransport>();
    }
}
