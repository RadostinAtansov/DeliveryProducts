namespace InkoOrders.Data.Model
{
    public class ClientsTransaction
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int TrasactionPaymentId { get; set; }
        public TransactionPayment TransactionPayment { get; set; }
    }
}
