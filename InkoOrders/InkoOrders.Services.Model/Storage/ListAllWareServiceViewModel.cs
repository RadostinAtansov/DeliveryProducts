using Microsoft.AspNetCore.Http;

namespace InkoOrders.Services.Model.Storage
{
    public class ListAllWareServiceViewModel
    {
        public string Name { get; set; }

        public bool ActiveOrOld { get; set; }

        public DateTime TimeActiveAndHowOld { get; set; }

        public int Quantity { get; set; }

        public bool Insignificant { get; set; }

        public string Comment { get; set; }

        public string PlaceInStorageAndCity { get; set; }

        public string Picture { get; set; }
    }
}
