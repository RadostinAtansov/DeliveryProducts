using InkoOrders.Data.Model;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Services.Model.Storage
{
    using static DataValidation;

    public class AddWareServiceViewModel
    {

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
        public IFormFile Picture { get; set; }

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; }
    }
}
