namespace InkoOrders.Data.Model.Accounting
{
    public class BankPayments
    {
        public int Id { get; set; }

        public string BankName { get; set; }

        public decimal PriceAmount { get; set; }

        public string IBAN { get; set; }

        public string Comment { get; set; }

        public ICollection<BankIncomeExpencesUtilitiBills> BankIncomeExpencesUtility { get; set; } = new HashSet<BankIncomeExpencesUtilitiBills>();

    }
}
