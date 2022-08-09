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

            var componentCheck = data.Components
                    .FirstOrDefault(x => x.Name == component.Name);

            if (componentCheck != null)
            {
                throw new ArgumentException("Can`t add same component!");
            }

            var addC = new Component()
            {
                Name = component.Name,
                BuyedTime = component.BuyedTime,
                PlaceInStorage = component.PlaceInStorage,
                City = component.City,
                Designation = component.Designation,
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

            if (component == null)
            {
                throw new NullReferenceException("Can`t add Invoice to component that not exist!");
            }

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

        public void Edit(EditComponentServiceViewModel model)
        {
            var component = data.Components
                 .Find(model.Id);

            if (string.IsNullOrWhiteSpace(component.Designation))
            {
                throw new NullReferenceException("Designation can`t be null");
            }

            component.Name = model.Name;
            component.Designation = model.Designation;
            component.City = model.City;
            component.PlaceInStorage = model.PlaceInStorage;
            component.Price = model.Price;
            component.BuyedTime = model.BuyedTime;
            component.Quantity = model.Quantity;
            component.Insignificant = model.Insignificant;
            component.Picture = model.Picture;
            component.Comment = model.Comment;

            data.SaveChanges();
        }

    }
}
