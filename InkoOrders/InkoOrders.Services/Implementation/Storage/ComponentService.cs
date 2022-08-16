﻿using InkoOrders.Data;
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

            if (model.Quantity < component.Quantity)
            {
                var quantit = component.Quantity - model.Quantity;

                var history = new HistoryStorage
                {
                    Name = component.Name,
                    Quantity = quantit,
                    ReasonTransaction = "Edit component down with",
                    Date = DateTime.Now
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
            }
            else if(model.Quantity > component.Quantity)
            {
                var quantit = model.Quantity - component.Quantity;

                var history = new HistoryStorage
                {
                    Name = component.Name,
                    Quantity = quantit,
                    ReasonTransaction = "Edit component up with",
                    Date = DateTime.Now
                };

                this.data.HistoryStorages.Add(history);
                data.SaveChanges();
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
