using Microsoft.AspNetCore.Http;

namespace InkoOrders.Services.Model.Storage
{
    public class AddCreatedByInkoServiceViewModel
    {
        public string Name { get; set; }

        public bool Created { get; set; }

        public string CreatedFrom { get; set; }

        public int Quantity { get; set; }

        public IFormFile Picture { get; set; }

        public DateTime TimeWhenCreated { get; set; }

        public bool Insignificant { get; set; }

        public string PlaceInStorageAndCity { get; set; }

        public string Comment { get; set; }
    }
}
