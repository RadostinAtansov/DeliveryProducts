namespace InkoOrders.Data.Model
{
    public class Document
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Comment { get; set; }

        public int TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}
