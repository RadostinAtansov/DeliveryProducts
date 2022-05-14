using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model.Storage
{
    using static DataValidation;

    public class WareInko
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(StorageName)]
        public string Name { get; set; }

        [Required]
        public bool ActiveOrOld { get; set; }

        [Required]
        public DateTime TimeActiveAndHowOld { get; set; }

        [Required]
        public int Quantity { get; set; }

        public bool Insignificant { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }
    }
}
