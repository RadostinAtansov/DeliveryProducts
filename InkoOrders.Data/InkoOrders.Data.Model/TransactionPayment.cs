namespace InkoOrders.Data.Model
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidation;

    public class TransactionPayment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(TransactionPaymentDescriptionLength)]
        public string Descriotion { get; set; }

        public DateTime TransactionTime { get; set; }

        [Required]
        public string LinkDocuments { get; set; }

        public decimal AdvancePayment { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }

        public ICollection<TransportAndTransactionPayment> Transports { get; set; } = new HashSet<TransportAndTransactionPayment>();

        public ICollection<ClientsTransaction> Clients { get; set; } = new HashSet<ClientsTransaction>();

        public ICollection<ProductsToDeliveryToOrderToTransactionPaymentToTransport> Products { get; set; } = new HashSet<ProductsToDeliveryToOrderToTransactionPaymentToTransport>();
    }
}