namespace InkoOrders.Data.Model
{
    public class DeliveryClient
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
    }
}
