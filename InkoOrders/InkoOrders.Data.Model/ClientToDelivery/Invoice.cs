using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Data.Model
{
    using static DataValidation;

    public class Invoice
    {
        public int Id { get; set; }

        //Recipient
        [Required]
        [MaxLength(NameCompanyInvoice)]
        public string RecipientCompanyName { get; set; }

        [Required]
        public string RecipientVATNomer { get; set; }

        public string? RecipientIdentifyNomer { get; set; }

        [Required]
        [MaxLength(CityInvoice)]
        public string RecipientCity { get; set; }

        [Required]
        [MaxLength(AddressInvoice)]
        public string RecipientAddress { get; set; }

        //MOL
        [Required]
        [MaxLength(NameInvoice)]
        public string RecipientNames { get; set; }
         
        public string? RecipientTelephone { get; set; }

        //Distributor
        [Required]
        [MaxLength(NameCompanyInvoice)]
        public string DistributorCompanyName { get; set; }

        [Required]
        public string DistributorVATNomer { get; set; }

        [Required]
        public string DistributorIdentifyNomer { get; set; }

        [Required]
        [MaxLength(CityInvoice)]
        public string DistributorCity { get; set; }

        [Required]
        [MaxLength(AddressInvoice)]
        public string DistributorAddress { get; set; }

        //MOL
        [Required]
        [MaxLength(DistributorNameLength)]
        public string DistributorNames { get; set; }

        [Required]
        public string DistributorTelephone { get; set; }

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; }

        public ICollection<Client> Clients { get; set; } = new HashSet<Client>();
    }
}
