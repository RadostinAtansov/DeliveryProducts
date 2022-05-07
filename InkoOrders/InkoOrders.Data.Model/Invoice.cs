namespace InkoOrders.Data.Model
{
    public class Invoice
    {
        public int Id { get; set; }

        //Recipient

        public string RecipientCompanyName { get; set; }

        public string RecipientVATNomer { get; set; }

        public string? RecipientIdentifyNomer { get; set; }

        public string RecipientCity { get; set; }

        public string RecipientAddress { get; set; }

        //MOL
        public string RecipientNames { get; set; }
         
        public string? RecipientTelephone { get; set; }

        //Distributor

        public string DistributorCompanyName { get; set; }

        public string DistributorVATNomer { get; set; }

        public string DistributorIdentifyNomer { get; set; }

        public string DistributorCity { get; set; }

        public string DistributorAddress { get; set; }

        //MOL
        public string DistributorNames { get; set; }

        public string DistributorTelephone { get; set; }

        public string Comment { get; set; }

        public int OrderId { get; set; }
        public Order OrderedProducts { get; set; }
    }
}
