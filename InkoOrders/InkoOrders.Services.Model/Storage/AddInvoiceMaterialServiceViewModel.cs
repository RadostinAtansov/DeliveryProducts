using Microsoft.AspNetCore.Http;

namespace InkoOrders.Services.Model.Storage
{
    public class AddInvoiceMaterialServiceViewModel
    {
        public int Id { get; set; }

        public string BoughtCompanyName { get; set; }

        public int Qantity { get; set; }

        public string ProductName { get; set; }

        public DateTime TimeWhenBoughtOnInvoice { get; set; }

        public IFormFile Picture { get; set; }

        public string Comment { get; set; }
    }
}
