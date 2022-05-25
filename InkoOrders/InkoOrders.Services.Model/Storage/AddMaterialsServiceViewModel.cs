namespace InkoOrders.Services.Model.Storage
{
    public class AddMaterialsServiceViewModel
    {
        public string Name { get; set; }

        public int Quаntity { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string PlaceInStorageAndCity { get; set; }

        public DateTime TimeInInko { get; set; }

        public bool Insignificant { get; set; }

        public string Comment { get; set; }
    }
}
