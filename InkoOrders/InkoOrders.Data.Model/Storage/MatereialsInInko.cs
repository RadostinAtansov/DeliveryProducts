using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class MatereialsInInko
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(StorageName)]
        public string Name { get; set; }

        [Required]
        public int Quаntity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Picture { get; set; }

        [Required]
        public string PlaceInStorageAndCity { get; set; }

        [Required]
        public DateTime TimeInInko { get; set; }

        public bool Insignificant { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }
    }
}
