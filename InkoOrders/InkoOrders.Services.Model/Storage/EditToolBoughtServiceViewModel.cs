using InkoOrders.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Services.Model.Storage
{
    using static DataValidation;

    public class EditToolBoughtServiceViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(StorageNameMaxLength, MinimumLength = StorageNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(StorageDesignationMaxLenght, MinimumLength = StorageDesignationMinLenght)]
        public string Designation { get; set; }

        public bool Bought { get; set; }

        [Required]
        [StringLength(StorageBoughtFromMaxLenght, MinimumLength = StorageBoughtFromMinLenght)]
        public string BoughtFrom { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeBought { get; set; }

        [Required]
        [Range(StorageQuantityMinLenght, StorageQuantityMaxLenght)]
        public int Quantity { get; set; }

        [Required]
        public string Picture { get; set; }

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
