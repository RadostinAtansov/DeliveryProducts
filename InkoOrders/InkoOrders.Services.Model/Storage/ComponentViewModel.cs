namespace InkoOrders.Services.Model.Storage
{
    public class ComponentViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime BuyedTime { get; set; }

        public bool Insignificant { get; set; }

        public string Picture { get; set; }

        public string PlaceInStorageAndCity { get; set; }

        public string Comment { get; set; }
    }
}
