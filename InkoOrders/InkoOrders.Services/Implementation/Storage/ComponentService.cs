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
                PlaceInStorage = component.PlaceInStorage,
                City = component.City,
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

        public void Edit(EditComponentServiceViewModel model)
        {
            var component = data.Components
                 .Find(model.Id);

            component.Name = model.Name;
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

        public EditComponentServiceViewModel Edit(int id)
        {
            var editComponent = data.Components
                .Select(c => new EditComponentServiceViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City,
                    Picture = c.Picture,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    BuyedTime = c.BuyedTime,
                    Comment = c.Comment,
                    PlaceInStorage = c.PlaceInStorage,
                    Insignificant = c.Insignificant,
                })
                .FirstOrDefault(x => x.Id == id);

            return editComponent;
        }

        public ICollection<ShowAllInvoiceServiceComponentViewModel> ShowInvoiceComponent(int id)
        {
            var allInvoices = data.InvoicesStorageComponents
                .Where(x => x.ComponentId == id)
                .Select(x => new ShowAllInvoiceServiceComponentViewModel
                {
                    BoughtFrom = x.BoughtCompanyName,
                    ProductName = x.ProductName,
                    TimeWhenBoughtOnInvoice = x.TimeWhenBoughtOnInvoice,
                    Quantity = x.Qantity,
                    Picture = x.Picture,
                    Comment = x.Comment
                })
                .ToList();

            return allInvoices;
        }
    }
}
