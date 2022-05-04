namespace InkoOrders.Data.Model
{
    public class TransactionPayment
    {
        public int Id { get; set; }

        public string Descriotion { get; set; }

        public DateTime TransactionTime { get; set; }

        //link kym dokumenta???
        public string LinkDocument { get; set; }

        public decimal AdvancePayment { get; set; } //avans za koito da se razberem

        public string Comment { get; set; }

        public ICollection<TransportAndTransactionPayments> TransportPayments { get; set; } = new HashSet<TransportAndTransactionPayments>();

        public ICollection<ClientTransactions> Transactions { get; set; } = new HashSet<ClientTransactions>();
    }
}