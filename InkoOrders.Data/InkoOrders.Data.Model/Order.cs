using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model
{
    using static DataValidation;

    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime Datetime { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        [MaxLength(OrderDistributorName)]
        public string Distributor { get; set; }

        public int OrderTimeout { get; set; }

        [Required]
        public decimal OrderPrice { get; set; }

        public ICollection<Product> OrderedProducts { get; set; } = new HashSet<Product>();

        [MaxLength(CommentLength)]
        public string Comment { get; set; }

        public ICollection<ClientsOrder> Clients { get; set; } = new HashSet<ClientsOrder>();

        public ICollection<ProductsToDeliveryToOrderToTransactionPaymentToTransport> Products { get; set; } = new HashSet<ProductsToDeliveryToOrderToTransactionPaymentToTransport>();
    }
}
