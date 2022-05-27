using InkoOrders.Data;
using InkoOrders.Data.Model.Storage;
using InkoOrders.Services.IStorageServices;
using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.Implementation.Storage
{
    public class WareInkoService : IWareInkoService
    {
        private readonly InkoOrdersDBContext data;

        public WareInkoService(InkoOrdersDBContext data)
        {
            this.data = data;
        }

        public void AddWare(AddWareServiceViewModel model)
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
            };

            data.WaresInko.Add(ware);
            data.SaveChanges();
        }
    }
}
