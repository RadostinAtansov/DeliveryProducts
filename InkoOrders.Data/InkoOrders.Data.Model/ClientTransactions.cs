namespace InkoOrders.Data.Model
{
    public class ClientTransactions
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int TrasactionPaymentId { get; set; }
        public TransactionPayment TransactionPayment { get; set; }
    }
}
