namespace InkoOrders.Data.Model
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string CompanyName { get; set; }

        public string DistributorName { get; set; }

        public string Address { get; set; }

        public int Telephone { get; set; }

        public string IBAN { get; set; }

        public string Email { get; set; }

        public string TaxRegistryNumber { get; set; }

        public string Comment { get; set; }

        //faktura
        public int InvoiceId{ get; set; }
        public Invoice Invoice { get; set; }

        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }

        public int TransportId { get; set; }
        public Transport Transport { get; set; }

        public ICollection<ClientTransactions> TransactionPayment { get; set; } = new List<ClientTransactions>();
        public ICollection<ClientsOrders> Orders { get; set; } = new HashSet<ClientsOrders>();
    }
}
