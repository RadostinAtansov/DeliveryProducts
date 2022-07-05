namespace Inko.Orders.Web.Models.Storage.Add
{
    public class AddMaterialViewModel
    {
        public string Name { get; set; }

        public int? Quаntity { get; set; }

        public decimal Price { get; set; }

        public IFormFile Picture { get; set; }

        public string PlaceInStorage { get; set; }
        
        public string City { get; set; }

        public DateTime TimeInInko { get; set; }

        public bool Insignificant { get; set; }

        public string Comment { get; set; }
    }
}
