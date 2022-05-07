using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model
{
    using static DataValidation;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductName)]
        public string Name { get; set; }

        [Url(ErrorMessage = "Please enter valid URL")]
        public string URL { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string Designation { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }

        public ICollection<ProductsToDeliveryToOrderToTransactionPaymentToTransport> ProDelOrdTranPayTran { get; set; } = new HashSet<ProductsToDeliveryToOrderToTransactionPaymentToTransport>();
        //public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        //public ICollection<Delivery> Deliveries { get; set; } = new HashSet<Delivery>();
        //public ICollection<Transport> Transports { get; set; } = new HashSet<Transport>();
        //public ICollection<TransactionPayment> TransactionPayments { get; set; } = new HashSet<TransactionPayment>();

    }
}
