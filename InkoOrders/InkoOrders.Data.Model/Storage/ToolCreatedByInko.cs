using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class ToolCreatedByInko
    {

        public int Id { get; set; }

        [Required]
        [StringLength(StorageNameMaxLength, MinimumLength = StorageNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(StorageDesignationMaxLenght, MinimumLength = StorageDesignationMinLenght)]
        public string Designation { get; set; }

        public bool Created { get; set; }

        [Required]
        [StringLength(StorageCreatedFromMaxLenght, MinimumLength = StorageCreatedFromMinLenght)]
        public string CreatedFrom { get; set; }

        [Required]
        [Range(StorageQuantityMaxLenght, StorageQuantityMinLenght)]
        public int Quantity { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeWhenCreated { get; set; }

        public bool Insignificant { get; set; }

        [Required]
        [StringLength(StoragePlaceInStorageMaxLenght, MinimumLength = StoragePlaceInStorageMinLenght)]
        public string PlaceInStorage { get; set; }

        [Required]
        [StringLength(StorageCityMaxLenght, MinimumLength = StorageCityMinLenght)]
        public string City { get; set; }

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; }

    }
}
