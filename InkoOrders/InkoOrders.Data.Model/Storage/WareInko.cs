using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Designation { get; set; }

        [Required]
        public DateTime TimeActiveAndHowOld { get; set; }

        [Required]
        public int Quantity { get; set; }

        public bool Insignificant { get; set; }

        [Required]
        public string PlaceInStorage { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Picture { get; set; }

        [MaxLength(CommentLength)]
        public string Comment { get; set; }

        public ICollection<InvoicesStorageWare> InvoicesWares { get; set; } = new HashSet<InvoicesStorageWare>();
    }
}
