using InkoOrders.Data;
using InkoOrders.Services.Model.Storage;
using InkoOrders.Data.Model.Storage;
using System.Globalization;

namespace InkoOrders.Services.Implementation
{
    public class StorageService : IStorageService
    {
        private readonly InkoOrdersDBContext data;

        public StorageService(InkoOrdersDBContext data)
        {
            this.data = data;
        }

        public void AddComponent(ComponentViewModel component)
        {
            if (string.IsNullOrEmpty(component.Name))
            {
                throw new ArgumentException("Name can`t be null or empty");
            }

            //var date = component.BuyedTime.ToString("dd/MM/yyyy");

            var addC = new Component()
            {
                Name = component.Name,
                BuyedTime = component.BuyedTime,
                PlaceInStorageAndCity = component.PlaceInStorageAndCity,
                Insignificant = component.Insignificant,
                Price = component.Price,
                Quantity = component.Quantity,
                Picture = component.Picture,
                Comment = component.Comment,
            };

            data.Components.Add(addC);
            data.SaveChanges();
        }
    }
}
