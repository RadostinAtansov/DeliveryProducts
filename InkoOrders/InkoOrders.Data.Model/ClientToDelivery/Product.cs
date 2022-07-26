using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model
{
    using static DataValidation;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string Name { get; set; }

        [Url(ErrorMessage = "Please enter valid URL")]
        public string URL { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string Designation { get; set; }

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; }

        public ICollection<ProductsToDeliveryToOrderToTransactionPaymentToTransport> ProDelOrdTranPayTran { get; set; } = new HashSet<ProductsToDeliveryToOrderToTransactionPaymentToTransport>();

    }
}
