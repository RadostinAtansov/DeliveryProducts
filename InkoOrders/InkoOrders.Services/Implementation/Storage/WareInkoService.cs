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

        public void AddWare(AddWareServiceViewModel model, string path)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentException("Name can`t be null or empty");
            }

            var ware = new WareInko() 
            {
                Name = model.Name,
                Quantity = model.Quantity,
                TimeActiveAndHowOld = model.TimeActiveAndHowOld,
                ActiveOrOld = model.ActiveOrOld,
                Insignificant = model.Insignificant,
                Comment = model.Comment,
                Picture = path,
                PlaceInStorageAndCity = model.PlaceInStorageAndCity,
            };

            data.WaresInko.Add(ware);
            data.SaveChanges();
        }

        //public ICollection<ListAllWareServiceViewModel> ListAll()
        //{
        //    var allWares = data.WaresInko
        //        .Select(w => new ListAllWareServiceViewModel
        //        {
        //            Name = w.Name,
        //            Quantity= w.Quantity,
        //            ActiveOrOld= w.ActiveOrOld,
        //            TimeActiveAndHowOld= w.TimeActiveAndHowOld,
        //            Insignificant= w.Insignificant,
        //            Comment = w.Comment,
        //            Picture = w.Picture,
        //            PlaceInStorageAndCity = w.PlaceInStorageAndCity,
                    
        //        })
        //        .ToList();

        //    return allWares;
        //}
    }
}