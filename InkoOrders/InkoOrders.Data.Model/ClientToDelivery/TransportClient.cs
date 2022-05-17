namespace InkoOrders.Data.Model
{
    public class TransportClient
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int TransportId { get; set; }
        public Transport Transport { get; set; }
    }
}
