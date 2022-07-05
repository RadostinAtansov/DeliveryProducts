using System.ComponentModel.DataAnnotations.Schema;

namespace Inko.Orders.Web.Models.Storage.Add
{
    public class AddInvoiceComponentViewModel
    {
        public int Id { get; set; }

        public string BoughtCompanyName { get; set; }

        public int Qantity { get; set; }

        public string ProductName { get; set; }

        public DateTime TimeWhenBoughtOnInvoice { get; set; }

        public string Comment { get; set; }

        public IFormFile Picture { get; set; }
    }
}
