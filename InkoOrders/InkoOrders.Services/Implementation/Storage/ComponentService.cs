using InkoOrders.Data;
using InkoOrders.Data.Model.Storage;
using InkoOrders.Services.Model.Storage;
using InkoOrders.Services.IStorageServices;
using System.Web.Mvc;

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
            var addC = new Component()
            {
                Picture = path,
                City = component.City,
                Name = component.Name,
                Price = component.Price,
                Comment = component.Comment,
                Quantity = component.Quantity,
                BuyedTime = component.BuyedTime,
                Designation = component.Designation,
                Insignificant = component.Insignificant,
                PlaceInStorage = component.PlaceInStorage,
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
                Picture = path,
                Qantity = model.Qantity,
                Comment = model.Comment,
                ProductName = model.ProductName,
                BoughtCompanyName = model.BoughtCompanyName,
                TimeWhenBoughtOnInvoice = model.TimeWhenBoughtOnInvoice,
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

            if (model.Quantity < component.Quantity)
            {
                var quantit = component.Quantity - model.Quantity;

                var history = new HistoryStorage
                {
                    Quantity = quantit,
                    Date = DateTime.Now,
                    Name = component.Name,
                    ReasonTransaction = "Edit component down with",
                    
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            else if(model.Quantity > component.Quantity)
            {
                var quantit = model.Quantity - component.Quantity;

                var history = new HistoryStorage
                {
                    Quantity = quantit,
                    Date = DateTime.Now,
                    Name = component.Name,
                    ReasonTransaction = "Edit component up with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }

            component.Name = model.Name;
            component.City = model.City;
            component.Price = model.Price;
            component.Picture = model.Picture;
            component.Comment = model.Comment;
            component.Quantity = model.Quantity;
            component.BuyedTime = model.BuyedTime;
            component.Designation = model.Designation;
            component.Insignificant = model.Insignificant;
            component.PlaceInStorage = model.PlaceInStorage;

            data.SaveChanges();
        }

    }
}
