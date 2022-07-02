using InkoOrders.Data;
using InkoOrders.Data.Model.Storage;
using InkoOrders.Services.Model.Storage;
using InkoOrders.Services.IStorageServices;

namespace InkoOrders.Services.Implementation.Storage
{
    public class ComponentService : IComponentService
    {
        private readonly InkoOrdersDBContext data;

        public ComponentService(InkoOrdersDBContext data)
        {
            this.data = data;
        }

        public void AddComponent(AddComponentServiceViewModel component, string path)
        {
            if (string.IsNullOrEmpty(component.Name))
            {
                throw new ArgumentException("Name can`t be null or empty");
            }

            var addC = new Component()
            {
                Name = component.Name,
                BuyedTime = component.BuyedTime,
                PlaceInStorageAndCity = component.PlaceInStorageAndCity,
                Insignificant = component.Insignificant,
                Price = component.Price,
                Quantity = component.Quantity,
                Picture = path,
                Comment = component.Comment,
            };

            data.Components.Add(addC);
            data.SaveChanges();
        }

        public void AddInvoiceComponent(AddInvoiceComponentServiceViewModel model, string path)
        {
            var component = data.Components.Find(model.Id);

            var invoice = new InvoicesStorageComponent
            {
                ProductName = model.ProductName,
                BoughtCompanyName = model.BoughtCompanyName,
                Qantity = model.Qantity,
                TimeWhenBoughtOnInvoice = model.TimeWhenBoughtOnInvoice,
                Comment = model.Comment,
                Picture = path,
            };

            component.Quantity += model.Qantity;

            component.InvoiceComponents.Add(invoice);
            data.SaveChanges();

        }
    }
}
