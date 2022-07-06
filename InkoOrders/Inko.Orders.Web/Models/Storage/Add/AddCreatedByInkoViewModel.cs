namespace Inko.Orders.Web.Models.Storage.Add
{
    public class AddCreatedByInkoViewModel
    {
        public string Name { get; set; }

        public string Designation { get; set; }

        public bool Created { get; set; }

        public string CreatedFrom { get; set; }

        public int Quantity { get; set; }

        public IFormFile Picture { get; set; }

        public DateTime TimeWhenCreated { get; set; }

        public bool Insignificant { get; set; }

        public string PlaceInStorage { get; set; }

        public string City { get; set; }

        public string Comment { get; set; }
    }
}
