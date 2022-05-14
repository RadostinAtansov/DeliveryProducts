namespace InkoOrders.Data.Model.Accounting
{
    public class Income
    {
        public int Id { get; set; }

        public decimal AllIncome { get; set; }

        public decimal FromStocks { get; set; }

        public decimal FromServices { get; set; }

        public ICollection<BankIncomeExpencesUtilitiBills> IncomePayments { get; set; } = new HashSet<BankIncomeExpencesUtilitiBills>();

    }
}
