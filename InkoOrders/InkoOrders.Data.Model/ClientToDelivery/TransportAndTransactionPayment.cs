namespace InkoOrders.Data.Model
{
    public class TransportAndTransactionPayment
    {
        public int TransportId { get; set; }
        public Transport Transport { get; set; }

        public int TransactionPaymentsId { get; set; }
        public TransactionPayment TransactionPayment { get; set; }
    }
}
