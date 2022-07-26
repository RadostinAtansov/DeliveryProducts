using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model
{
    using static DataValidation;

    public class Delivery
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameDeliveryLength)]
        public string DeliveryCompanyName { get; set; }

        [Required]
        public DateTime PredicationDate { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        [Required]
        public decimal EndPrice { get; set; }

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; }

        [Required]
        public string Payments { get; set; }


        public ICollection<DeliveryClient> Clients { get; set; } = new HashSet<DeliveryClient>();

        public ICollection<ProductsToDeliveryToOrderToTransactionPaymentToTransport> Products { get; set; } = new HashSet<ProductsToDeliveryToOrderToTransactionPaymentToTransport>();

    }
}
