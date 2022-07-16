
namespace InkoOrders.Data.Model.Storage
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidation;

    public class InvoicesStorageMaterial
    {
        public int Id { get; set; }

        [Required]
        [StringLength(StorageNameMaxLength, MinimumLength = StorageNameMinLength)]
        public string BoughtCompanyName { get; set; }

        [Required]
        [Range(StorageQuantityMinLenght, StorageQuantityMaxLenght)]
        public int Qantity { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TimeWhenBoughtOnInvoice { get; set; }

        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; }

        [Required]
        public string Picture { get; set; }

        public int MaterialId { get; set; }
        public MaterialsInInko Material { get; set; }
    }
}
