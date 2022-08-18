using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Services.Model.Storage
{
    public class AddInvoiceWareServiceViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string BoughtCompanyName { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Must be between 0 and 2147483647")]
        public int Qantity { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeWhenBoughtOnInvoice { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [StringLength(1000, MinimumLength = 0)]
        public string Comment { get; set; }
    }
}
