namespace InkoOrders.Data.Model.Accounting
{
    public class Expences
    {
        public int Id { get; set; }

        public decimal AllExpences { get; set; }

        public ICollection<BankIncomeExpencesUtilitiBills> ExpencesPayments { get; set; } = new HashSet<BankIncomeExpencesUtilitiBills>();
    }
}
