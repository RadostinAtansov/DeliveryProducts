using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class ToolBoughtByInko
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(StorageName)]
        public string Name { get; set; }

        public string Designation { get; set; }

        public bool Bought { get; set; }

        public string BoughtFrom { get; set; }

        public DateTime TimeBought{ get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Picture { get; set; }

        public bool Insignificant { get; set; }

        [Required]
        public string PlaceInStorage { get; set; }

        [Required]
        public string City { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }

        public ICollection<InvoicesStorageToolBoughtByInko> InvoicesToolsBoughtByInko { get; set; } = new HashSet<InvoicesStorageToolBoughtByInko>();
    }
}
