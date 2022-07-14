using InkoOrders.Data;
using InkoOrders.Data.Model;
using InkoOrders.Data.Model.Storage;
using InkoOrders.Services.IStorageServices;
using InkoOrders.Services.Model.Storage;
using Microsoft.AspNetCore.Hosting;

namespace InkoOrders.Services.Implementation.Storage
{
    public class WareInkoService : IWareInkoService
    {
        private readonly InkoOrdersDBContext data;

        public WareInkoService(InkoOrdersDBContext data)
        {
            this.data = data;
        }

        public void AddInvoiceToWare(AddInvoiceWareServiceViewModel model, string path)
        {
            var ware = data.WaresInko.Find(model.Id);

            if (ware == null)
            {
                throw new NullReferenceException("Can`t add Invoice to ware that not exist!");
            }

            var invoice = new InvoicesStorageWare
            {
                ProductName = model.ProductName,
                BoughtCompanyName = model.BoughtCompanyName,
                Qantity = model.Qantity,
                TimeWhenBoughtOnInvoice = model.TimeWhenBoughtOnInvoice,
                Comment = model.Comment,
                Picture = path,
            };

            ware.Quantity += model.Qantity;

            ware.InvoicesWares.Add(invoice);
            data.SaveChanges();
        }

        public void AddWare(AddWareServiceViewModel model, string path)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentException("Name can`t be null or empty");
            }

            var wareCheck = data.Components
                   .FirstOrDefault(x => x.Name == model.Name);

            if (wareCheck != null)
            {
                throw new ArgumentException("Can`t add same ware!");
            }

            var ware = new WareInko() 
            {
                Name = model.Name,
                Designation = model.Designation,
                Quantity = model.Quantity,
                TimeActiveAndHowOld = model.TimeActiveAndHowOld,
                ActiveOrOld = model.ActiveOrOld,
                Insignificant = model.Insignificant,
                Comment = model.Comment,
                Picture = path,
                PlaceInStorage = model.PlaceInStorage,
                City = model.City,
            };

            data.WaresInko.Add(ware);
            data.SaveChanges();
        }

        public void Edit(EditWareServiceViewModel model)
        {
            var ware = data.WaresInko
                 .Find(model.Id);

            ware.Name = model.Name;
            ware.Designation = model.Designation;
            ware.City = model.City;
            ware.PlaceInStorage = model.PlaceInStorage;
            ware.Quantity = model.Quantity;
            ware.Insignificant = model.Insignificant;
            ware.Picture = model.Picture;
            ware.Comment = model.Comment;

            data.SaveChanges();
        }

    }
}