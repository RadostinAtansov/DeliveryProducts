namespace InkoOrders.Data.Model
{
    public static class DataValidation
    {
        //ClientDelivery
        public const int NameClientLength = 500;
        public const int CityClientLength = 50;
        public const int CompanyNameClientLength = 50;
        public const int DistributorNameClientLength = 50;
        public const int AddressNameClientLength = 100;

        //All comments
        public const int CommentLength = 1000;

        public const int NameDeliveryLength = 80;

        public const int NameInvoice = 80;
        public const int NameCompanyInvoice = 80;
        public const int CityInvoice = 50;
        public const int AddressInvoice = 100;

        public const int DistributorNameLength = 100;

        public const int OrderDistributorName = 100;

        public const int ProductName = 100;

        public const int TransactionPaymentDescriptionLength = 1000;

        public const int TransportFromCompany = 100;
        public const int TransportToClient = 100;

        //Storage
        public const int StorageName = 100;
    }
}
