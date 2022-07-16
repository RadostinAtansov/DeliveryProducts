using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class ProviderOrder
    {
        public int Id { get; set; }

        /// <summary>
        /// 
        /// Identifier
        ///
        /// се съставя на следния принцип:“ 210900-3“ , първите две числа(21) показват годината на заявката, следващите две(09) показват месеца а(00) ден от месеца.Ако не се въвежда ден или е неизвестен се вписва „00“. (-3) показва поредността за поръчки за един и същи ден.
        /// </summary>
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
        [Range(1, int.MaxValue)]
        public int HowManyProductsOrderedByPosition { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Arrived { get; set; }

        [Required]
        [Range(StoragePriceMinLenght, StoragePriceMaxLenght)]
        public decimal? Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ArrivedQuantityAndProductsFromOrder { get; set; }

        public OrderStatusProvider Status { get; set; }

        public DateTime ChangeStatusChangeDatetime { get; set; }
    }
}
