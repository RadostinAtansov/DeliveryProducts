using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class InvoicesStorageWare
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

        public int WareInkoId { get; set; }
        public WareInko Ware { get; set; }
    }
}
