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
        public const int CommentMaxLength = 1000;
        public const int CommentMinLength = 5;

        public const int NameDeliveryLength = 80;

        public const int NameInvoice = 80;
        public const int NameCompanyInvoice = 80;
        public const int CityInvoice = 50;
        public const int AddressInvoice = 100;

        public const int DistributorNameLength = 100;

        public const int OrderDistributorName = 100;

        public const int ProductNameMaxLength = 100;
        public const int ProductNameMinLength = 3;

        public const int TransactionPaymentDescriptionLength = 1000;

        public const int TransportFromCompany = 100;
        public const int TransportToClient = 100;

        //Storage
        public const int StorageNameMinLength = 5;
        public const int StorageNameMaxLength = 100;

        public const int StorageDesignationMinLenght = 5;
        public const int StorageDesignationMaxLenght = 1000;

        public const int StorageQuantityMinLenght = 0;
        public const int StorageQuantityMaxLenght = int.MaxValue;

        public const int StoragePlaceInStorageMinLenght = 10;
        public const int StoragePlaceInStorageMaxLenght = 1000;

        public const int StorageCityMinLenght = 2;
        public const int StorageCityMaxLenght = 100;

        public const int StoragePriceMinLenght = 0;
        public const int StoragePriceMaxLenght = int.MaxValue;

        public const int StorageIdentifierMinLenght = 5;
        public const int StorageIdentifierMaxLenght = 1000;

        public const int StorageOrderDesciptionMinLenght = 5;
        public const int StorageOrderDesciptionMaxLenght = 1000;

        public const int StorageBoughtFromMinLenght = 3;
        public const int StorageBoughtFromMaxLenght = 100;

        public const int StorageCreatedFromMinLenght = 3;
        public const int StorageCreatedFromMaxLenght = 100;
    }
}
