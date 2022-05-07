using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class Components
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(StorageName)]
        public int Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime BuyedTime { get; set; }

        public string Picture { get; set; }

        [Required]
        public string PlaceInStorageAndCity { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }
    }
}
