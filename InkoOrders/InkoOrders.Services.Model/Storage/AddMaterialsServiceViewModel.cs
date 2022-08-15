using InkoOrders.Data.Model;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Services.Model.Storage
{

    using static DataValidation;

    public class AddMaterialsServiceViewModel
    {
        [Required]
        [StringLength(StorageNameMaxLength, MinimumLength = StorageNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(StorageQuantityMinLenght, StorageQuantityMaxLenght)]
        public int? Quantity { get; set; }

        [Required]
        [StringLength(StorageDesignationMaxLenght, MinimumLength = StorageDesignationMinLenght)]
        public string Designation { get; set; }

        [Required]
        [Range(StoragePriceMinLenght, StoragePriceMaxLenght)]
        public decimal Price { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        [StringLength(StoragePlaceInStorageMaxLenght, MinimumLength = StoragePlaceInStorageMinLenght)]
        public string PlaceInStorage { get; set; }

        [Required]
        [StringLength(StorageCityMaxLenght, MinimumLength = StorageCityMinLenght)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeInInko { get; set; }

        public bool Insignificant { get; set; }

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; }
    }
}
