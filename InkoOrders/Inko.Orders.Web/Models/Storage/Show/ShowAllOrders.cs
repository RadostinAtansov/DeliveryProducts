using InkoOrders.Data.Model.Storage;

namespace Inko.Orders.Web.Models.Storage.Show
{
    public class ShowAllOrders
    {
        public string Identifier { get; set; }

        public string ProviderName { get; set; }

        public string OrderDescription { get; set; }

        public int Quantity { get; set; }

        public string URL { get; set; }

        public DateTime OrderedDate { get; set; }

        public int HowManyProductsOrderedByPosition { get; set; }

        public DateTime Arrived { get; set; }

        public decimal? Price { get; set; }

        public string ArrivedQuantityAndProductsFromOrder { get; set; }

        public OrderStatusProvider Status { get; set; }

        public DateTime ChangeStatusChangeDatetime { get; set; }
    }
}
