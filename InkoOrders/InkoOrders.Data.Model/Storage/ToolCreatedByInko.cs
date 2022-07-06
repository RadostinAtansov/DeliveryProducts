using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class ToolCreatedByInko
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(StorageName)]
        public string Name { get; set; }

        public string Designation { get; set; }

        public bool Created { get; set; }

        public string CreatedFrom { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Picture { get; set; }

        public DateTime TimeWhenCreated { get; set; }

        public bool Insignificant { get; set; }

        [Required]
        public string PlaceInStorage { get; set; }

        [Required]
        public string City { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }

    }
}
