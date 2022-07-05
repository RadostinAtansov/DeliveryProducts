using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    //using static DataValidation;

    public class InvoicesStorageComponent
    {
        public int Id { get; set; }

        public string BoughtCompanyName { get; set; }

        public int Qantity { get; set; }

        public string ProductName { get; set; }

        public DateTime TimeWhenBoughtOnInvoice { get; set; }

        public string Comment { get; set; }

        public string Picture { get; set; }

        public int ComponentId { get; set; }
        public Component Component { get; set; }
    }
}
