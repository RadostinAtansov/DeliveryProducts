using System.ComponentModel.DataAnnotations.Schema;

namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowAllComponentsViewModel
    {
        public int Id { get; set; }

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
