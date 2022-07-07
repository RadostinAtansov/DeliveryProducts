namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowAllCreatedToolsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public bool Created { get; set; } = true;

        public string CreatedFrom { get; set; }

        public int Quantity { get; set; }

        public string Picture { get; set; }

        public DateTime TimeWhenCreated { get; set; }

        public bool Insignificant { get; set; }

        public string PlaceInStorage { get; set; }

        public string City { get; set; }

        public string Comment { get; set; }
    }
}
