namespace InkoOrders.Data.Model.Accounting
{
    public class UtilityBills
    {
        public int Id { get; set; }

        public decimal Water { get; set; }

        public decimal Electricity { get; set; }

        public decimal Stocks { get; set; }

        public decimal Transport { get; set; }

        public decimal Customs { get; set; }

        public decimal CoPerformars { get; set; }

        public decimal Others { get; set; }

        public ICollection<BankIncomeExpencesUtilitiBills> UtilityPayments { get; set; } = new HashSet<BankIncomeExpencesUtilitiBills>();
    }
}
