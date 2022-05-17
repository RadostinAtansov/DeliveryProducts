namespace InkoOrders.Data.Model.Accounting
{
    public class BankIncomeExpencesUtilitiBills
    {
        public int BankPaymentsId { get; set; }
        public BankPayments BankPayment { get; set; }

        public int IncomeId { get; set; }
        public Income Income { get; set; }

        public int UtilityBillsId { get; set; }
        public UtilityBills UtilityBill { get; set; }

        public int ExpencesId { get; set; }
        public Expences Expence { get; set; }

    }
}
