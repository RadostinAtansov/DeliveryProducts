namespace Inko.Orders.Web.Models.Storage.Add
{
    public class AddComponentViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public decimal Price { get; set; }

        public int? Quantity { get; set; }

        public DateTime BuyedTime { get; set; }

        public bool Insignificant { get; set; }

        public IFormFile Picture { get; set; }

        public string PlaceInStorage { get; set; }

        public string City { get; set; }

        public string Comment { get; set; }
    }
}
