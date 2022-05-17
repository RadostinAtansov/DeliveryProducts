using InkoOrders.Data.Model.ClientToDelivery;
using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model
{
    using static DataValidation;

    public class RegisterOrderForProduction
    {
        public int Id { get; set; }

        [Required]
        public string OrderNameAndCountry { get; set; }


        /// <summary>
        /// 
        /// Identifier
        /// 
        /// Making By Specific Way: Съставя се на следния принцип:“ 210900-EEMC“ , първите две числа(21) показват годината на заявката, следващите две(09) показват месеца а (00) ден от месеца. Ако не се въвежда ден или е неизвестен се вписва „00“. (-EEMC) показва за кой продукт се отнася поръчката.
        /// </summary>
        public string Identifier { get; set; } 

        [EmailAddress]
        public string Email{ get; set; }

        [Required]
        public DateTime OrderedDatetime { get; set; }

        public DateTime FinishhOrderDatetime { get; set; }

        public DateTime SendOrderDatetime { get; set; }

        public string WayBill { get; set; }

        public OrderStatus StatusOrder { get; set; }

        [Required]
        [MaxLength(OrderDistributorName)]
        public string Distributor { get; set; }

        public int OrderTimeout { get; set; }

        [Required]
        public decimal OrderPrice { get; set; }


        [MaxLength(CommentLength)]
        public string Comment { get; set; }

        public ICollection<Product> OrderedProducts { get; set; } = new HashSet<Product>();

        public ICollection<ClientsOrder> Clients { get; set; } = new HashSet<ClientsOrder>();

        public ICollection<ProductsToDeliveryToOrderToTransactionPaymentToTransport> Products { get; set; } = new HashSet<ProductsToDeliveryToOrderToTransactionPaymentToTransport>();
    }
}
