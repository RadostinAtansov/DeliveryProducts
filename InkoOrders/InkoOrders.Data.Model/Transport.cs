namespace InkoOrders.Data.Model
{
    public class Transport
    {
        public int Id { get; set; }

        public string FromCompany { get; set; }

        public DateTime DatetimeOrdered { get; set; }

        public string ToClient { get; set; }

        public DateTime DatetimeArrive { get; set; }

        public List<string> Documents { get; set; }

        public ICollection<TransportAndTransactionPayments> Payments { get; set; } = new HashSet<TransportAndTransactionPayments>();

        public ICollection<Product> ProductsOrdered { get; set; }

    }
}
