using InkoOrders.Data;
using InkoOrders.Data.Model.Storage;
using InkoOrders.Services.Model.Storage;
using InkoOrders.Services.IStorageServices;

namespace InkoOrders.Services.Implementation.Storage
{
    public class ProviderOrderService : IProviderOrder
    {
        private readonly InkoOrdersDBContext data;

        public ProviderOrderService(InkoOrdersDBContext data)
        {
            this.data = data;
        }

        public void AddProviderOrder(AddProviderServiceViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ProviderName))
            {
                throw new ArgumentException("Provider name can`t be null or white space");
            }

            var order = new ProviderOrder()
            {
               ProviderName = model.ProviderName,
               Arrived = model.Arrived,
               ArrivedQuantityAndProductsFromOrder = model.ArrivedQuantityAndProductsFromOrder,
               ChangeStatusChangeDatetime = model.ChangeStatusChangeDatetime,
               HowManyProductsOrderedByPosition = model.HowManyProductsOrderedByPosition,
               Identifier = model.Identifier,
               OrderDescription = model.OrderDescription,
               OrderedDate = model.OrderedDate,
               Price = model.Price,
               Quantity = model.Quantity,
               Status = model.Status,
               URL = model.URL
            };

            data.ProviderOrders.Add(order);
            data.SaveChanges();
        }
    }
}
