using InkoOrders.Data.Model;
using InkoOrders.Data.Model.Storage;
using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Services.Model.Storage
{

    using static DataValidation;

    public class AddProviderServiceViewModel
    {
        [Required]
        [StringLength(StorageIdentifierMaxLenght, MinimumLength = StorageIdentifierMinLenght)]
        public string Identifier { get; set; }

        [Required]
        [StringLength(StorageNameMaxLength, MinimumLength = StorageNameMinLength)]
        public string ProviderName { get; set; }

        [Required]
        [StringLength(StorageOrderDesciptionMaxLenght, MinimumLength = StorageOrderDesciptionMinLenght)]
        public string OrderDescription { get; set; }

        [Required]
        [Range(StorageQuantityMinLenght, StorageQuantityMaxLenght)]
        public int Quantity { get; set; }

        [Url]
        [Required]
        public string URL { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderedDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int HowManyProductsOrderedByPosition { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Arrived { get; set; }

        [Required]
        [Range(StoragePriceMinLenght, StoragePriceMaxLenght)]
        public decimal? Price { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public string ArrivedQuantityAndProductsFromOrder { get; set; }

        public OrderStatusProvider Status { get; set; } //  <==== da se opravi

        public DateTime ChangeStatusChangeDatetime { get; set; }
    }
}
