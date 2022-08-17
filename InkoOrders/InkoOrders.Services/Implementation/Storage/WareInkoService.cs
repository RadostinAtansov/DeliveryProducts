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
                Picture = path,
                Qantity = model.Qantity,
                Comment = model.Comment,
                ProductName = model.ProductName,
                BoughtCompanyName = model.BoughtCompanyName,
                TimeWhenBoughtOnInvoice = model.TimeWhenBoughtOnInvoice,
            };

            ware.Quantity += model.Qantity;

            ware.InvoicesWares.Add(invoice);
            data.SaveChanges();
        }

        public void AddWare(AddWareServiceViewModel model, string path)
        {
            var ware = new WareInko() 
            {
                Picture = path,
                Name = model.Name,
                City = model.City,
                Comment = model.Comment,
                Quantity = model.Quantity,
                Designation = model.Designation,
                ActiveOrOld = model.ActiveOrOld,
                Insignificant = model.Insignificant,
                PlaceInStorage = model.PlaceInStorage,
                TimeActiveAndHowOld = model.TimeActiveAndHowOld,
            };

            data.WaresInko.Add(ware);
            data.SaveChanges();
        }

        public void Edit(EditWareServiceViewModel model)
        {
            var ware = data.WaresInko
                 .Find(model.Id);

            if (model.Quantity < ware.Quantity)
            {
                var quantit = ware.Quantity - model.Quantity;

                var history = new HistoryStorage
                {
                    Name = ware.Name,
                    Quantity = quantit,
                    Date = DateTime.Now,
                    ReasonTransaction = "Edit Ware down with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            else if (model.Quantity > ware.Quantity)
            {
                var quantit = model.Quantity - ware.Quantity;

                var history = new HistoryStorage
                {
                    Name = ware.Name,
                    Quantity = quantit,
                    Date = DateTime.Now,
                    ReasonTransaction = "Edit Ware up with",
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            ware.Name = model.Name;
            ware.City = model.City;
            ware.Picture = model.Picture;
            ware.Comment = model.Comment;
            ware.Quantity = model.Quantity;
            ware.Designation = model.Designation;
            ware.Insignificant = model.Insignificant;
            ware.PlaceInStorage = model.PlaceInStorage;

            data.SaveChanges();
        }

    }
}