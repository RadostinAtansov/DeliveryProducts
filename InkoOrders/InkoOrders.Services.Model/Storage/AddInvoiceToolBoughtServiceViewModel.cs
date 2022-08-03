using Microsoft.AspNetCore.Http;

namespace InkoOrders.Services.Model.Storage
{
    public class AddInvoiceToolBoughtServiceViewModel
    {
        public int Id { get; set; }

        public string BoughtCompanyName { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }

        public DateTime TimeWhenBoughtOnInvoice { get; set; }

        public string Comment { get; set; }

        public IFormFile Picture { get; set; }
    }
}
