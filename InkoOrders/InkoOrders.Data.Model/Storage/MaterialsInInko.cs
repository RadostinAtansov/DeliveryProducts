using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class MaterialsInInko
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(StorageName)]
        public string Name { get; set; }

        public int? Quantity { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Picture { get; set; }

        [Required]
        public string PlaceInStorage { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public DateTime TimeInInko { get; set; }

        public bool Insignificant { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }

        public ICollection<InvoicesStorageMaterial> InvoicesMaterial { get; set; } = new HashSet<InvoicesStorageMaterial>();
    }
}
