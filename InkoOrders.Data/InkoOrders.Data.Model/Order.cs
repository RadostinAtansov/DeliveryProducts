namespace InkoOrders.Data.Model
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Datetime { get; set; }

        public Client Client { get; set; }

        public string Distributor { get; set; }

        public int OrderTimeout { get; set; }

        public decimal OrderPrice { get; set; }

        public ICollection<Product> OrderedProducts { get; set; }

        public string Comment { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public ICollection<ClientsOrders> Clients { get; set; } = new HashSet<ClientsOrders>();
    }
}
