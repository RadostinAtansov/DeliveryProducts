using System.ComponentModel.DataAnnotations;

namespace InkoOrders.Services.Model.Storage
{
    public class EditComponentServiceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100000000, ErrorMessage = "Quantity can`t be under zero")]
        public int? Quantity { get; set; }

        public DateTime BuyedTime { get; set; }

        public bool Insignificant { get; set; }

        public string Picture { get; set; }

        public string PlaceInStorage { get; set; }

        public string City { get; set; }

        public string Comment { get; set; }
    }
}
