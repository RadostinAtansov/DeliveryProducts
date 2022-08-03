namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowAllInvoicesToolCreatedViewModel
    {
        public int Id { get; set; }

        public string BoughtFrom { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }

        public DateTime TimeWhenCreatedOnInvoice { get; set; }

        public string Comment { get; set; }

        public string Picture { get; set; }
    }
}
