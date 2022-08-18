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

        public void AddInvoicetoOrder(AddInvoiceProviderOrderServiceViewModel model, string path)
        {
            var order = data.ProviderOrders.Find(model.Id);

            var orderInvoice = new InvoiceStorageProviderOrder()
            {
                  Picture = path,
                  Price = model.Price,
                  Arrived = model.Arrived,
                  Comment = model.Comment,
                  Quantity = model.Quantity,
                  ProductName = model.ProductName,
                  TimeWhenBought = model.TimeWhenBought,
                  WhenWillItBeDelivered = model.WhenWillItBeDelivered,
            };
            order.InvoiceStorageProviderOrder.Add(orderInvoice);
            data.SaveChanges();
        }

        public void AddProviderOrder(AddProviderServiceViewModel model)
        {

            var order = new ProviderOrder()
            {
               URL = model.URL,
               Price = model.Price,
               Status = model.Status,
               Arrived = model.Arrived,
               Quantity = model.Quantity,
               Identifier = model.Identifier,
               OrderedDate = model.OrderedDate,
               ProviderName = model.ProviderName,
               OrderDescription = model.OrderDescription,
               ChangeStatusChangeDatetime = model.ChangeStatusChangeDatetime,
               HowManyProductsOrderedByPosition = model.HowManyProductsOrderedByPosition,
               ArrivedQuantityAndProductsFromOrder = model.ArrivedQuantityAndProductsFromOrder,
            };

            data.ProviderOrders.Add(order);
            data.SaveChanges();
        }

        public void EditOrder(EditProviderOrdertServiceViewModel model)
        {
            var order = data.ProviderOrders
                 .Find(model.Id);

            if (model.Quantity < order.Quantity)
            {
                var quantit = order.Quantity - model.Quantity;

                var history = new HistoryStorage
                {
                    Quantity = quantit,
                    Date = DateTime.Now,
                    Name = order.ProviderName,
                    ReasonTransaction = "Edit Order down with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            else if (model.Quantity > order.Quantity)
            {
                var quantit = model.Quantity - order.Quantity;

                var history = new HistoryStorage
                {
                    Quantity = quantit,
                    Date = DateTime.Now,
                    Name = order.ProviderName,
                    ReasonTransaction = "Edit Order up with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            order.URL = model.URL;
            order.Status = model.Status;
            order.Arrived = model.Arrived;
            order.Quantity = model.Quantity;
            order.Identifier = model.Identifier;
            order.OrderedDate = model.OrderedDate;
            order.ProviderName = model.ProviderName;
            order.OrderDescription = model.OrderDescription;
            order.ChangeStatusChangeDatetime = model.ChangeStatusChangeDatetime;
            order.HowManyProductsOrderedByPosition = model.HowManyProductsOrderedByPosition;
            order.ArrivedQuantityAndProductsFromOrder = model.ArrivedQuantityAndProductsFromOrder;

            data.SaveChanges();
        }
    }
}
