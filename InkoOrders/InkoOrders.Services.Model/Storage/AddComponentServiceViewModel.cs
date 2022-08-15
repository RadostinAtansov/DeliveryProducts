using InkoOrders.Data.Model;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Services.Model.Storage
{

    using static DataValidation;

    public class AddComponentServiceViewModel
    {
        [Required]
        [StringLength(StorageNameMaxLength, MinimumLength = StorageNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = $"Must be between this too 0 and 2147483647")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(StorageDesignationMaxLenght, MinimumLength = StorageDesignationMinLenght)]
        public string Designation { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = $"Must be between this too 0 and 2147483647")]
        public int? Quantity { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BuyedTime { get; set; }

        public bool Insignificant { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

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
