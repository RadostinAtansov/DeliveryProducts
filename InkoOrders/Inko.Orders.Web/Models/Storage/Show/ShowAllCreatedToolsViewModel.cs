namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowAllCreatedToolsViewModel
    {
        public string Name { get; set; }

        public bool Created { get; set; } = true;

        public string CreatedFrom { get; set; }

        public int Quantity { get; set; }

        public string Picture { get; set; }

        public DateTime TimeWhenCreated { get; set; }

        public bool Insignificant { get; set; }

        public string PlaceInStorageAndCity { get; set; }

        public string Comment { get; set; }
    }
}
