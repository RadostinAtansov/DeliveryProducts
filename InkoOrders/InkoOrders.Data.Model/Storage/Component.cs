using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class Component
    {
        public int Id { get; set; }

        [Required]
        [StringLength(StorageNameMaxLength , MinimumLength = StorageNameMinLength)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(StorageDesignationMaxLenght, MinimumLength = StorageDesignationMinLenght)]
        public string Designation { get; set; }

        [Required]
        [Range(StorageQuantityMinLenght, StorageQuantityMaxLenght)]
        public int? Quantity { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BuyedTime { get; set; }

        public bool Insignificant { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        [StringLength(StoragePlaceInStorageMaxLenght, MinimumLength = StoragePlaceInStorageMinLenght)]
        public string PlaceInStorage { get; set; }

        [Required]
        [StringLength(StorageCityMaxLenght, MinimumLength = StorageCityMinLenght)]
        public string City { get; set; }

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; }

        public ICollection<InvoicesStorageComponent> InvoiceComponents { get; set; } = new HashSet<InvoicesStorageComponent>();
    }
}
