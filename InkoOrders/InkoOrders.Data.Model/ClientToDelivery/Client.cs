using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model
{
    using static DataValidation;

    public class Client
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(NameClientLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(CityClientLength)]
        public string City { get; set; }

        [Required]
        [MaxLength(CompanyNameClientLength)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(DistributorNameClientLength)]
        public string DistributorName { get; set; }

        [Required]
        [MaxLength(AddressNameClientLength)]
        public string Address { get; set; }

        [Required]
        public int Telephone { get; set; }

        [Required]
        public string IBAN { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string TaxRegistryNumber { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }

        public List<Product> ProductsClient { get; set; }

        //one invoice
        public int InvoiceId{ get; set; }
        public Invoice Invoice { get; set; }

        public ICollection<ProductsToDeliveryToOrderToTransactionPaymentToTransport> Products { get; set; } = new HashSet<ProductsToDeliveryToOrderToTransactionPaymentToTransport>();

        public ICollection<TransportClient> TransportClients { get; set; } = new HashSet<TransportClient>();

        public ICollection<DeliveryClient> Deliveries { get; set; } = new HashSet<DeliveryClient>();

        public ICollection<ClientsTransaction> TransactionPayments { get; set; } = new List<ClientsTransaction>();

        public ICollection<ClientsOrder> Orders { get; set; } = new HashSet<ClientsOrder>();
    }
}
