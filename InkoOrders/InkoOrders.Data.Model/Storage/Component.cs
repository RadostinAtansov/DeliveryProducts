using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class Component
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(StorageName)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime BuyedTime { get; set; }

        public bool Insignificant { get; set; }

        public string Picture { get; set; }

        [Required]
        public string PlaceInStorageAndCity { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }

        public ICollection<InvoicesStorageComponent> InvoiceComponents { get; set; } = new HashSet<InvoicesStorageComponent>();
    }
}
