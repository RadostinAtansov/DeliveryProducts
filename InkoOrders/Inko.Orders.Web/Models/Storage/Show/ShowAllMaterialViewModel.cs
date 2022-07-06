namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowAllMaterialViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Quаntity { get; set; }

        public string Designation { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string PlaceInStorage { get; set; }

        public string City { get; set; }

        public DateTime TimeInInko { get; set; }

        public bool Insignificant { get; set; }

        public string Comment { get; set; }
    }
}
