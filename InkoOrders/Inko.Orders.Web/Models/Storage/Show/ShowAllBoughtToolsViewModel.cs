namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowAllBoughtToolsViewModel
    {
        public string Name { get; set; }

        public bool Bought { get; set; }

        public string BoughtFrom { get; set; }

        public DateTime TimeBought { get; set; }

        public int Quantity { get; set; }

        public string Picture { get; set; }

        public bool Insignificant { get; set; }

        public string PlaceInStorageAndCity { get; set; }

        public string Comment { get; set; }
    }
}
