using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class WareInko
    {
        public int Id { get; set; }

        [Required]
        [StringLength(StorageNameMaxLength, MinimumLength = StorageNameMinLength)]
        public string Name { get; set; }

        [Required]
        public bool ActiveOrOld { get; set; }

        [Required]
        [StringLength(StorageDesignationMaxLenght, MinimumLength = StorageDesignationMinLenght)]
        public string Designation { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeActiveAndHowOld { get; set; }

        [Required]
        [Range(StorageQuantityMaxLenght, StorageQuantityMinLenght)]
        public int Quantity { get; set; }

        public bool Insignificant { get; set; }

        [Required]
        [StringLength(StoragePlaceInStorageMaxLenght, MinimumLength = StoragePlaceInStorageMinLenght)]
        public string PlaceInStorage { get; set; }

        [Required]
        [StringLength(StorageCityMaxLenght, MinimumLength = StorageCityMinLenght)]
        public string City { get; set; }

        [Required]
        public string Picture { get; set; }

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; }

        public ICollection<InvoicesStorageWare> InvoicesWares { get; set; } = new HashSet<InvoicesStorageWare>();
    }
}
