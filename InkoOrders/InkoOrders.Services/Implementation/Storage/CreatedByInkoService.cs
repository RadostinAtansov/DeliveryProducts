using InkoOrders.Data;
using InkoOrders.Data.Model.Storage;
using InkoOrders.Services.IStorageServices;
using InkoOrders.Services.Model.Storage;

namespace InkoOrders.Services.Implementation.Storage
{
    public class CreatedByInkoService : ICreatedByInkoService
    {
        private readonly InkoOrdersDBContext data;

        public CreatedByInkoService(InkoOrdersDBContext data)
        {
            this.data = data;
        }

        public void AddCreated(AddCreatedByInkoServiceViewModel model, string path)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentException("Name can`n be null or empty");
            }

            var created = new ToolCreatedByInko()
            {
                Name = model.Name,
                Created = true,
                Picture = path,
                PlaceInStorageAndCity = model.PlaceInStorageAndCity,
                Comment = model.Comment,
                CreatedFrom = model.CreatedFrom,
                Insignificant = model.Insignificant,
                Quantity = model.Quantity,
                TimeWhenCreated = model.TimeWhenCreated,
            };

            data.ToolCreatedByInko.Add(created);
            data.SaveChanges();
        }
    }
}
