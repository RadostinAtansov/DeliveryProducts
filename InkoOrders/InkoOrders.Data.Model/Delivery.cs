namespace InkoOrders.Data.Model
{
    public class Delivery
    {
        public int Id { get; set; }

        public string DeliveryCompanyName { get; set; }

        public DateTime PredicationDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public decimal EndPrice { get; set; }

        public string Comment { get; set; }

        public string Payments { get; set; }

        public List<Product> ProductsInOrder { get; set; }

        public ICollection<Client> Clients { get; set; } = new HashSet<Client>();

    }
}
